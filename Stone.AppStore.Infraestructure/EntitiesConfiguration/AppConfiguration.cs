using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stone.AppStore.Domain.Entities;
using System;

namespace Stone.AppStore.Infraestructure.EntitiesConfiguration
{
    public class AppConfiguration : IEntityTypeConfiguration<App>
    {
        public void Configure(EntityTypeBuilder<App> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasData(
              new App(Guid.NewGuid(), "Facebook", true, 10.50, "Meta"),
              new App(Guid.NewGuid(), "Instagram", true, 1.50, "Meta"),
              new App(Guid.NewGuid(), "Stone",true, 100, "Stone")
            );
        }
    }
}
