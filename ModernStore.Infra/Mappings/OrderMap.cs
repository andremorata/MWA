using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Mappings
{
    public class OrderMap: EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Order");
            HasKey(i => i.Id);
            Property(i => i.CreateDate);
            Property(i => i.DeliveryFee)
                .HasColumnType("money");
            Property(i => i.Discount)
                .HasColumnType("money");
            Property(i => i.Number)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();
            Property(i => i.Status);

            HasMany(i => i.Items);
            HasRequired(i => i.Customer);
        }
    }
}
