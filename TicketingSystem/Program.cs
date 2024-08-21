
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Infrastructure;
using TicketingSystem.Infrastructure.Repositories;
using TicketingSystem.Application;
using TicketingSystem.Domain.Abstractions;

namespace TicketingSystem;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<TicketDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("TicketsDb")));
        builder.Services.AddScoped<ITicketRepository, TicketRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddApplicationServices();
        //builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Program).Assembly));

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
