using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stone.AppStore.Domain.Entities;
using Stone.AppStore.Infraestructure.Identity;

namespace Stone.AppStore.Infraestructure.Context
{
    public class AppStoreDbContext : IdentityDbContext<User>
    {
        public AppStoreDbContext(DbContextOptions<AppStoreDbContext> options)
            : base(options)
        { }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<App> Apps { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppStoreDbContext).Assembly);
        }
    }
}
