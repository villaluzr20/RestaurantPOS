using Microsoft.EntityFrameworkCore;

public class RestaurantDbContext : DbContext
{
    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RestaurantDbContext>();
        optionsBuilder.UseSqlite("Data Source=restaurant.db");

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<MenuItem>().HasIndex(m => m.Name).IsUnique();
    }
                
}