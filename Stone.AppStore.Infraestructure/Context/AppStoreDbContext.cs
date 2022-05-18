using Microsoft.EntityFrameworkCore;
using Stone.AppStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.AppStore.Infraestructure.Context
{
    public class AppStoreDbContext : DbContext
    {
        public AppStoreDbContext(DbContextOptions<AppStoreDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<App> Apps { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppStoreDbContext).Assembly);

            builder.Entity<User>(opts =>
            {
                opts.HasKey(u => u.Id);
            });

            builder.Entity<Address>(opts =>
            {
                opts.HasOne(a => a.User)
                    .WithOne();
            });

            builder.
        }
    }
}
