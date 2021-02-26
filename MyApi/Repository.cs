using Microsoft.EntityFrameworkCore;
using MyApi.Interfacies;
using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi
{
  public class Repository : IRepository
  {
    public ApplicationContext _context;
    public Repository(ApplicationContext applicationContext)
    {
      _context = applicationContext;
    }


    public void AddNewCarInCompany(int CompanyId, Car car)
    {
      var comp = _context.Companies.FirstOrDefault(c => c.Id == CompanyId);
      car.Company = comp;
      _context.Add(car);
      _context.SaveChanges();
    }

    public void AddNewCompany(Company company)
    {
      {
        _context.Add(company);
        _context.SaveChanges();
      }
    }
   
    public void AddNewDriverInOneCompany(int CompanyId, int CarId, Driver driver)
    {

      var res = _context.Cars.Include(z => z.Company).FirstOrDefault(x=>x.Id==CarId);
      driver.Cars.Add(res);
      _context.Add(driver);
      _context.SaveChanges();



      //var comp = _context.Companies.FirstOrDefault(c => c.Id == CompanyId);
      //var car2 = _context.Cars.FirstOrDefault(c => c.Id == CarId);
      //driver.Cars.Add(car2);
      //_context.Add(driver);
      //_context.SaveChanges();
    }

    public void DeleteCompany(int id)
    {
      var res = _context.Companies.FirstOrDefault(c => c.Id == id);
      _context.Companies.Remove(res);
      _context.SaveChanges();

    }

    public void DeleteOneCarFromCompany(int CompanyId, int CarId)
    {
      var res = _context.Cars.Include(z => z.Company).FirstOrDefault(x=>x.Id==CarId);
        _context.Cars.Remove(res);
        _context.SaveChanges();

      //var comp = _context.Companies.FirstOrDefault(x => x.Id == CompanyId);
      //var car1 = _context.Cars.FirstOrDefault(c => c.Id == CarId);
      //if (car1.CompanyId == comp.Id)
      //{
      //  _context.Cars.Remove(car1);
      //  _context.SaveChanges();
      //}
    }
    //=========================================
    public void DeleteOneDriverFromCompany(int CompanyId, int CarId, int DriverId)
    {
      var driv = _context.Drivers.FirstOrDefault(l=> l.Id == DriverId);
      var res=_context.Cars.Include(x=>x.Drivers).Include(z=>z.Company).FirstOrDefault(c => c.Id == CarId);
      //вытягиваю конкретную машину и все что с ней связано
      res.Drivers.Remove(driv);

      _context.SaveChanges();
    }
    //========================================================
    public Company GetAboutOneCompany(int CompanyId)
    {
      var res = _context.Companies.FirstOrDefault(x => x.Id == CompanyId);
      return res;
    }

    public List<Car> GetAllAboutCompanies()
    {
      var res = _context.Cars.Include(x => x.Company).ToList();
      return res;
    }
    //===============================================================================
    public void UpdateOneCarInOneCompany(int CompanyId, Car car, int CarId)
    {
      var res = _context.Cars.Include(z => z.Company).FirstOrDefault(x=>x.Id==CarId);
        res.Model = car.Model;
        _context.Cars.Update(res);
        _context.SaveChanges();

      //var comp = _context.Companies.FirstOrDefault(z => z.Id == CompanyId);
      //var car1 = _context.Cars.FirstOrDefault(z => z.Id == CarId);
      //if (car1.CompanyId == comp.Id)
      //{
      //  car1.Model = car.Model;
      //  _context.Cars.Update(car1);
      //  _context.SaveChanges();
      //}
    }
    //==============================================================================
    public void UpdateOneDriverInOneCompany(int CompanyId, Driver driver, int DriverId)
    {
      var res = _context.Drivers.Include(x => x.Cars).ThenInclude(z => z.Company).FirstOrDefault(z=>z.Id== DriverId);
      res.Name = driver.Name;
      _context.Drivers.Update(res);
      _context.SaveChanges();
    }
  }
}
