using Microsoft.EntityFrameworkCore;

namespace AdminApi.Entities
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}