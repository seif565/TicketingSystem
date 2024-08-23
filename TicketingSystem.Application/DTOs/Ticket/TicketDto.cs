namespace TicketingSystem.Application.DTOs.Ticket;

public record TicketDto(int Id, DateTime CreatedAt, string PhoneNumber, string Governorate, string City, string District);
