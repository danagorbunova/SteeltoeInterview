using Microsoft.EntityFrameworkCore;

namespace AdminApi.Entities
{
    public class AdminDbContext : DbContext, IDbContext
    {
        private string _connectionString { get; set; }

        public DbSet<User> Users {get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(_connectionString);

        public AdminDbContext(AppConfig appConfig)
        {
            if (appConfig == null)
                throw new ArgumentNullException(nameof(appConfig));

            _connectionString = appConfig.DbConnectionString;
        }

        int IDbContext.SaveChanges()
        {
            return SaveChanges();
        }
    }
}