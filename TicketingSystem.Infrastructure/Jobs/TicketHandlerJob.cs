using TicketingSystem.Application.Jobs;
using TicketingSystem.Domain.Abstractions;

namespace TicketingSystem.Infrastructure.Jobs
{
    public class TicketHandlerJob : ITicketHandlerJob
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketHandlerJob(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task UpdateTicketStatusesAsync(CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}
