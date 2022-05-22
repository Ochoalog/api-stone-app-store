using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stone.AppStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.AppStore.Infraestructure.EntitiesConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
        }
    }
}
