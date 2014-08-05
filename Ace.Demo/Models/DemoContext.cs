using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Ace.Demo.Models.Mapping;

namespace Ace.Demo.Models
{
    public partial class DemoContext : DbContext
    {
        static DemoContext()
        {
            Database.SetInitializer<DemoContext>(null);
        }

        public DemoContext()
            : base("Name=DemoContext")
        {
        }

        public DbSet<News> News { get; set; } 
        public DbSet<Role> Roles { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NewsMap());
            modelBuilder.Configurations.Add(new RoleMap());
        }
    }
}
