using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TicketingSystem.Application.Jobs
{
    public interface IHangFireSetup
    {
        void ConfigureHangfire(IServiceCollection services, IConfiguration configuration);
        void ScheduleRecurringJobs(IServiceProvider serviceProvider);
    }
}
