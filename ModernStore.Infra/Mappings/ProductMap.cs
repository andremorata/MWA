using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.Mappings
{
    public class ProductMap: EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");
            HasKey(i => i.Id);

            Property(i => i.Image)
                .IsRequired()
                .HasMaxLength(1024);
            Property(i => i.Price)
                .HasColumnType("money");
            Property(i => i.QuantityOnHand);
            Property(i => i.Title)
                .IsRequired()
                .HasMaxLength(160);
        }
    }
}
