using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<TruckCompany> TruckCompanies { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Terminal> Terminals { get; set; }
    public DbSet<Container> Containers { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
}
