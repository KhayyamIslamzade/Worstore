using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Worstore.Entities;

namespace Worstore.AccessLayer.Entity
{

    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<SpokenLanguage> SpeekingLanguage { get; set; }
        public DbSet<Word> Word { get; set; }
        public DbSet<Meaning> Meaning { get; set; }

    }
}
