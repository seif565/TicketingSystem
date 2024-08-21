
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Infrastructure;
using TicketingSystem.Infrastructure.Repositories;
using TicketingSystem.Domain.Abstractions;
using TicketingSystem.Application.Extensions;
using TicketingSystem.Application.Jobs;
using Hangfire;

namespace TicketingSystem;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<TicketDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("TicketsDb")));
        builder.Services.AddScoped<ITicketRepository, TicketRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddTransient<IHangFireSetup, HangFireSetup>();
        builder.Services.AddApplicationServices();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var hangFireSetup = builder.Services.BuildServiceProvider().GetRequiredService<IHangFireSetup>();
        hangFireSetup.ConfigureHangfire(builder.Services, builder.Configuration);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.UseHangfireDashboard();

        using (var scope = app.Services.CreateScope())
        {
            hangFireSetup.ScheduleRecurringJobs(scope.ServiceProvider);
        }

        app.MapControllers();

        app.Run();
    }
}
