using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models
{
  public class Car
  {
    public int Id { get; set; }
    [Required]
    public string Model { get; set; }
    
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public List<Driver> Drivers { get; set; } = new List<Driver>();
  }
}
