using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketingSystem.Application.Jobs;
using TicketingSystem.Infrastructure.Jobs;

namespace TicketingSystem.Infrastructure;

public class HangFireSetup : IHangFireSetup
{
    public void ConfigureHangfire(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHangfire(config => config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection")));

        services.AddHangfireServer();
        services.AddScoped<ITicketHandlerJob, TicketHandlerJob>();
    }

    public void ScheduleRecurringJobs(IServiceProvider serviceProvider)
    {
        var recurringJobManager = serviceProvider.GetRequiredService<IRecurringJobManager>();
        var ticketStatusUpdater = serviceProvider.GetRequiredService<ITicketHandlerJob>();

        recurringJobManager.AddOrUpdate(
            "UpdateTicketStatuses",
            () => ticketStatusUpdater.UpdateTicketStatusesAsync(CancellationToken.None),
            "*/15 * * * *"); // Every 15 minutes
    }
}