using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataAccess;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlServer("Server=ECOMZ-D-AH-L;Database=datindapp.db;User ID=sa;Password=p@ssw0rd;TrustServerCertificate=True");
        }
    }

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Music> Musics { get; set; }
}

