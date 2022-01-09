using System;
using AM.Projekt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Projekt.Infrastructure.Database.EF.TypeConfigurations
{
    public class ApplicationRoleTypeConfig : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            
            builder.HasKey(x => x.Id);
            builder.HasData(new ApplicationRole()
            {
                Id = Guid.Parse("dc3e3a54-7064-408d-b210-6ff8baa0e09c"),
                Name = "Admin"
            });
            
            builder.HasData(new ApplicationRole()
            {
                Id = Guid.Parse("ca0bd966-d3dc-4e05-9a55-e7a6e425b85d"),
                Name = "User",
            });
        }
    }
}