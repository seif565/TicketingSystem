namespace TicketingSystem.Application.Jobs
{
    public interface ITicketHandlerJob
    {
        Task UpdateTicketStatusesAsync(CancellationToken cancellationToken);
    }
}
