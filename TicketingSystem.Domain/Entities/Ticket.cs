using System.Diagnostics.Tracing;
using TicketingSystem.Domain.Enums;
using TicketingSystem.Domain.Primitives;
using TicketingSystem.Domain.ValueObjects;

namespace TicketingSystem.Domain.Entities;

public class Ticket : Entity
{
    private Ticket()
    {
        
    }
    private Ticket(string phoneNumber, Governorate governorate, City city, District district)
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
    public Governorate Governorate { get; private set; }
    public City City { get; private set; }
    public District District { get; private set; }
    public bool Handled { get; private set; }
    public static Ticket Create( string phoneNumber, Governorate governorate, City city, District district)
        => new Ticket(phoneNumber, governorate, city, district);

    public void HandleTicket() => Handled = true;
    

    public void ChangeTicketColor()
    {
        TicketColor = (DateTime.Now - CreatedAt).TotalMinutes switch
        {
            >= 60 => TicketColor.Red,
            >= 45 => TicketColor.Blue,
            >= 30 => TicketColor.Green,
            _ => TicketColor.Yellow,
        };
    }

    public void HandleOverDueTickets()
    {
        if((DateTime.Now - CreatedAt).TotalMinutes >= 60)
        {
            Handled = true;
        };
    }
}
