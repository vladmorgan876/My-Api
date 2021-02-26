using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi
{
  public static class DbSeeds
  {
    public static void Seed(ApplicationContext context)
    {
      if (!context.Companies.Any())
      {
        Company company1 = new Company { Name = "GilStroy-1" };
    Company company2 = new Company { Name = "GilStroy-2" };

    Car car1 = new Car { Model = "KRAZ", Company = company1 };
    Car car2 = new Car { Model = "GAZ", Company = company1 };
    Car car3 = new Car { Model = "GAZEL", Company = company2 };
    Car car4 = new Car { Model = "MERSEDES", Company = company2 };
    Car car5 = new Car { Model = "VOLVO", Company = company2 };

    Driver driver1 = new Driver { Name = "Ivanov", Cars = new List<Car>() { car1, car2 } };
    Driver driver2 = new Driver { Name = "Petrov", Cars = new List<Car>() { car2, car3 } };
    Driver driver3 = new Driver { Name = "Sidorov", Cars = new List<Car>() { car1, car3 } };
    Driver driver4 = new Driver { Name = "Zelenskiy", Cars = new List<Car>() { car1, car4 } };
    Driver driver5 = new Driver { Name = "Poroshenko", Cars = new List<Car>() { car1, car2, car3, car5 } };
    Driver driver6 = new Driver { Name = "Kravchuk", Cars = new List<Car>() { car2 } };

    context.Drivers.AddRange(driver1, driver2, driver3, driver4, driver5, driver6);
        context.Companies.AddRange(company1, company2);
        context.Cars.AddRange(car1, car2, car3, car4, car5);
        context.SaveChanges();
      }

}
  }
}
