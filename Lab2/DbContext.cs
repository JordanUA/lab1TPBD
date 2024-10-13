using Microsoft.EntityFrameworkCore;

public class AdsDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Ad> Ads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=localhost;Initial Catalog=AdsDB;Integrated Security=True;TrustServerCertificate=True"
        );
    }
}
