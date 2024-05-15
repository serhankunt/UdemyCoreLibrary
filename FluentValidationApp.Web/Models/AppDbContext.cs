using Microsoft.EntityFrameworkCore;

namespace FluentValidationApp.Web.Models;

public class AppDbContext : DbContext
{
    //private readonly IConfiguration _configuration;
  
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        //_configuration = configuration;
    }

   
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }
}
