using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models 
{
  public class ApplicationContext : DbContext
  {
    public DbSet<Car> Cars { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }
  }
}
