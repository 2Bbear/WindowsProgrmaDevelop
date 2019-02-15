using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WpfAuth.DataLayer
{
    public class WpfAuthDbContext : DbContext
    {
        public DbSet<StdDept> Depts { get; set; }
        public DbSet<StdRole> Roles { get; set; }
        public DbSet<StdUserDept> UserDepts { get; set; }
        public DbSet<StdUserRole> UserRoles { get; set; }
        public DbSet<StdUser> StdUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
