using System.Runtime.CompilerServices;

namespace TicketingSystem.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int id) : base($"Ticket with Id {id} was not found."){}
    }
}
