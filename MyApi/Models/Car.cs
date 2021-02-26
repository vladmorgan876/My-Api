using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models
{
  public class Car
  {
    public int Id { get; set; }
    public string Model { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public List<Driver> Drivers { get; set; } = new List<Driver>();
  }
}
