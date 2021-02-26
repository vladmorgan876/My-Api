using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models
{
  public class Driver
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Car> Cars { get; set; } = new List<Car>();
  }
}
