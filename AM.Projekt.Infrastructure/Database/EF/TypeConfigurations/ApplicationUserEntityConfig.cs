using AM.Projekt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Projekt.Infrastructure.Database.EF.TypeConfigurations
{
    public class UserEntityConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Name).HasMaxLength(100);
            
            builder.Property(x => x.Surname).HasMaxLength(100);
            
        }
    }
}