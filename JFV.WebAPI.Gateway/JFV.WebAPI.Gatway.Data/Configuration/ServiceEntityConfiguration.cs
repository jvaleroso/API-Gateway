using System.Data.Entity.ModelConfiguration;

namespace JFV.WebAPI.Gateway.Data.Configuration
{
    internal class ServiceEntityConfiguration: EntityTypeConfiguration<Service>
    {
        public ServiceEntityConfiguration()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasMaxLength(128);
            Property(e => e.Name).IsRequired().HasMaxLength(50);
            Property(e => e.Host).IsRequired().HasMaxLength(150);
            Property(e => e.Port).IsRequired();
            Property(e => e.Uri).IsRequired().HasMaxLength(50);
        }
    }
}
