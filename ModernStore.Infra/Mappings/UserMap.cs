using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Mappings
{
    public class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(i => i.Id);

            Property(i => i.Username)
                .IsRequired()
                .HasMaxLength(20);
            Property(i => i.Password)
                .IsRequired()
                .HasMaxLength(32)
                .IsFixedLength();
            Property(i => i.Active);
        }
    }
}
