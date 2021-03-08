using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyApi.Models
{
  public class Company
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public List<Car> Cars { get; set; }
  }
}
