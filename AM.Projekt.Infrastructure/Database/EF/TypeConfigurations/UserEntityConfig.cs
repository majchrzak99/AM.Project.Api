using AM.Projekt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Projekt.Infrastructure.Database.EF.TypeConfigurations
{
    public class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Name).HasMaxLength(100);
            
            builder.Property(x => x.Surname).HasMaxLength(100);
            
            builder.Property(x => x.Email).HasMaxLength(200);
        }
    }
}