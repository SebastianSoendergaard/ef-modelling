using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private const string DbPath = "c:\\temp\\ef-modelling\\data.db";

        public DbSet<User.UserRegistration> UserRegistrations { get; set; }
        public DbSet<User.User> Users { get; set; }
        public DbSet<UserGroup.UserGroup> UserGroups { get; set; }

        public DbContext()
        {
            var dir = Path.GetDirectoryName(DbPath);
            Directory.CreateDirectory(dir);
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}
