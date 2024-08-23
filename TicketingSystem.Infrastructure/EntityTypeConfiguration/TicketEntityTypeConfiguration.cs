using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.EntityTypeConfiguration;

public class TicketEntityTypeConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.OwnsOne(x => x.Governorate, owned =>
        {
            owned.Property(g => g.Name).HasColumnName("GovernorateName");
        });

        builder.OwnsOne(x => x.City, owned =>
        {
            owned.Property(c => c.Name).HasColumnName("CityName");
        });

        builder.OwnsOne(x => x.District, owned =>
        {
            owned.Property(d => d.Name).HasColumnName("DistrictName");
        });        
    }
}
