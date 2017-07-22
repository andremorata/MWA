using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.Mappings
{
    public class OrderItemMap: EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            ToTable("OrderItem");
            HasKey(i => i.Id);

            Property(i => i.Price)
                .HasColumnType("money");
            Property(i => i.Quantity);
            HasRequired(i => i.Product);
        }
    }
}
