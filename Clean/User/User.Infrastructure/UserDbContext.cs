using Microsoft.EntityFrameworkCore;

namespace User.Infrastructure
{
    internal class UserDbContext : DbContext
    {
        private const string DbPath = "c:\\temp\\ef-modelling\\data.db";

        public DbSet<Domain.UserRegistration.UserRegistration> UserRegistrations { get; set; }
        public DbSet<Domain.User.User> Users { get; set; }

        public UserDbContext()
        {
            var dir = Path.GetDirectoryName(DbPath);
            Directory.CreateDirectory(dir);
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
        }
    }
}
