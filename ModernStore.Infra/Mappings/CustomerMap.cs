using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Mappings
{
    public class CustomerMap: EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customer");
            HasKey(i => i.Id);
            Property(i => i.BirthDate);
            Property(i => i.Document.Number)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength();
            Property(i => i.Email.Address)
                .IsRequired()
                .HasMaxLength(160);
            Property(i => i.Name.FirstName)
                .IsRequired()
                .HasMaxLength(60);
            Property(i => i.Name.LastName)
                .IsRequired()
                .HasMaxLength(60);
            HasRequired(i => i.User);
        }
    }
}
