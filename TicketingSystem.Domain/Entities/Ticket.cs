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
            TicketColor = TicketColor.Yellow;
        }

        public DateTime CreatedAt { get; private set; }
        public string PhoneNumber { get; private set; }
        public TicketColor TicketColor { get; private set; }
        public string Governorate { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }
        public bool Handled { get; private set; }
        public static Ticket Create( string phoneNumber, string governorate, string city, string district)
            => new Ticket(phoneNumber, governorate, city, district);

        public void HandleTicket() => Handled = true;
        

        public void ChangeTicketColor()
        {
            TicketColor = (CreatedAt - DateTime.Now).TotalMinutes switch
            {
                > 60 => TicketColor.Red,
                >= 45 => TicketColor.Blue,
                >= 30 => TicketColor.Green,
                _ => TicketColor.Yellow,
            };
        }
    }
}
