using TicketingSystem.Domain.Enums;
using TicketingSystem.Domain.Primitives;

namespace TicketingSystem.Domain.Entities
{
    public class Ticket : Entity
    {
        private Ticket(string phoneNumber, string governorate, string city, string district)
        {
            CreatedAt = DateTime.Now;
            PhoneNumber = phoneNumber;
            Governorate = governorate;
            City = city;
            District = district;
            TicketStatus = TicketStatus.Yellow;
        }

        public DateTime CreatedAt { get; private set; }
        public string PhoneNumber { get; private set; }
        public TicketStatus TicketStatus { get; private set; }
        public string Governorate { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }
        public static Ticket Create( string phoneNumber, string governorate, string city, string district)
            => new Ticket(phoneNumber, governorate, city, district);

        public void HandleTicket()
        {
            TicketStatus = (DateTime.Now - CreatedAt).TotalMinutes switch
            {
                > 60 => TicketStatus.Red,
                >= 45 => TicketStatus.Blue,
                >= 30 => TicketStatus.Green,
                _ => TicketStatus.Red,
            };
        }
    }
}
