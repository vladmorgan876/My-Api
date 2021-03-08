using Microsoft.EntityFrameworkCore;
using MyApi.Interfacies;
using MyApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyApi
{
  public class Mod
  {
    public string Car { get; set; }
    public string Company { get; set; }
    public string Driver { get; set; }
    public string Message { get; set; }
  }

  public static class Messages
  {
    public static string NotFound(string text, int? param)
    {
      return ($"{text} {param} not found");
    }
    public static string AllOk()
    {
      return "All OK";
    }
    public static string ErrorInput()
    {
      return "ERROR !!! Required field is empty";
    }
  }
  public class Repository : IRepository
  {
    public ApplicationContext _context;
    public Repository(ApplicationContext applicationContext)
    {
      _context = applicationContext;
    }

//++++++++++++++++++++++++++++++++++++++++++++++++++++ 1+++++++++++++
    public string AddNewCarInCompany(int? CompanyId, Car car)
    {
      var results = new List<ValidationResult>();
      var context = new ValidationContext(car);
      if (!Validator.TryValidateObject(car, context, results, true) )
      {
        foreach (var error in results)
        {
          return error.ErrorMessage;
        }
      }
      if (CompanyId == null)
      {
        return Messages.ErrorInput();
      }
      var comp = _context.Companies.FirstOrDefault(c => c.Id == CompanyId);
      if (comp==null)
      {
        return Messages.NotFound("Company with ID:", CompanyId);
      }
      car.Company = comp;
      _context.Add(car);
      _context.SaveChanges();
      return Messages.AllOk();
    }
//+++++++++++++++++++++++++++++++++++++++++++++++++ 2
    public string  AddNewCompany(Company company)
     // валидация если в аргументы прилетает объект
    // в определении класса объявил using System.ComponentModel.DataAnnotations;
    // и присвоил свойству Name свойство [required] потом смотри ниже:
    {
      var results = new List<ValidationResult>();
      var context = new ValidationContext(company);
      if (!Validator.TryValidateObject(company, context, results, true))
      {
        foreach (var error in results)
        {
          return error.ErrorMessage;
        }
      }
        _context.Add(company);
        _context.SaveChanges();
      return Messages.AllOk();
    }
 //+++++++++++++++++++++++++++++++++++++   3 +++++++
    public string AddNewDriverInOneCompany(int? CompanyId, int? CarId, Driver driver)
    {
      var results = new List<ValidationResult>();
      var context = new ValidationContext(driver);
      if (!Validator.TryValidateObject(driver, context, results, true))
      {
        foreach (var error in results)
        {
          return error.ErrorMessage;
        }
      }
      if (CompanyId==null)
      {
        return Messages.ErrorInput();
      }
      if (CarId == null)
      {
        return Messages.ErrorInput();
      }
      var res = _context.Cars.Include(z => z.Company).FirstOrDefault(x => x.Id == CarId);
      if (res==null)
      {
        return Messages.NotFound("Car with Id:", CarId);
      }
      if (res.CompanyId == CompanyId)
      {
        driver.Cars.Add(res);
        _context.Add(driver);
        _context.SaveChanges();
        string[] text = { res.Model, " ", "ID:", res.Id.ToString(), " водитель:", driver.Name, " успешно был добавлен в компанию:", res.Company.Name };
        // TODO: Варианты конкатенаций строки
        // string test = $"{res.Model} ID: ";
        // string test2 = res.Model + " ";
        string mess = string.Concat(text);
        return mess;
      }
      else
      {
        string[] text = { res.Model, " ", "ID:", res.Id.ToString(), " ", "эта машина не пренадлежит этой компании,водитель не был добавлен" };
        string mess = string.Concat(text);
        return mess;
      }
    }
//+++++++++++++++++++++++++++++ 4  ++++  +++++++++++++++++++++++++++++++++++++
    public string DeleteCompany(int? id)
    {
      //if (id is null)
      //{
      //  throw new ArgumentNullException(nameof(id));
      //}

      if (id == null)
      {
        return Messages.ErrorInput();
      }

      var res = _context.Companies.FirstOrDefault(c => c.Id == id);
      if (res == null)
      {
        return Messages.NotFound("company with ID:", id);
      }

      _context.Companies.Remove(res);
      _context.SaveChanges();
      return Messages.AllOk();
    }
    //=============    5 ++++    ========================
    public string DeleteOneCarFromCompany(int? CompanyId, int? CarId)
      // по сути сюда можно передать только машинку и все должно работать но мы не ищем легких путей ТРЕНЕРУЙСЯ
    {
      var res2 = _context.Companies.Include(q=>q.Cars).FirstOrDefault(x => x.Id == CompanyId);
      var res = _context.Cars.Include(z => z.Company).FirstOrDefault(x => x.Id == CarId);
      if (CompanyId == null || CarId == null)
      {
        return Messages.ErrorInput();
      }
      if (res2==null)
      {
        return Messages.NotFound("Company with Id:", CompanyId);
      }
      if (res == null)
      {
        return Messages.NotFound("Car with Id:", CarId);
      }
      if (res.CompanyId != res2.Id)
      {
        string message = "Автомобиль с Id:" + CarId + " не пренадлежит компании с ID:" + CompanyId;
        return message;
      }

      _context.Cars.Remove(res);
      _context.SaveChanges();
      return Messages.AllOk();

    }
    //=========  6  ++++  ==================
    public string DeleteOneDriverFromCompany(int? CompanyId, int? CarId, int? DriverId)
    {
      if (CompanyId == null || CarId == null || DriverId == null)
      {
        return Messages.ErrorInput();
      }
      var res2 = _context.Companies.Include(x=>x.Cars).FirstOrDefault(z => z.Id == CompanyId);
      if (res2 == null)
      {
        return Messages.NotFound("Company with Id:", CompanyId);
      }
      var driv = _context.Drivers.FirstOrDefault(l => l.Id == DriverId);
      if (driv==null)
      {
        return Messages.NotFound("Driver with Id:", DriverId);
      }
      var res = _context.Cars.Include(x => x.Drivers).Include(z => z.Company).FirstOrDefault(c => c.Id == CarId);
      //вытягиваю конкретную машину и все что с ней связано
      if (res==null)
      {
        return Messages.NotFound("Car with Id:", CarId);
      }
      foreach (var d in res.Drivers)
      {
        if (d.Name != driv.Name)
        {
           string test2 = "Водитель "+driv.Name + " не работает на автомобиле: "+res.Model+" на компанию :"+res.Company.Name;
          return test2;
        }
      }
      foreach (var c in res2.Cars)
      {
        if (c.Model != res.Model)
        {
          string test2 = "Автомобиль " + res.Model + " не пренадлежит компании: " + res2.Name ;
          return test2;
        }
      }
      res.Drivers.Remove(driv);
      _context.SaveChanges();
      return Messages.AllOk();
    }
    //=========  7 +++    ==========================
    public List<Mod> GetAboutOneCompany(int CompanyId)
    {
      List<Mod> result = new List<Mod>();
      var res = _context.Companies.Include(x => x.Cars).ThenInclude(z => z.Drivers).FirstOrDefault(x => x.Id == CompanyId);
      if (res==null)
      {
         Mod  message = new Mod();
        message.Message = "Компания с Id:"+ CompanyId+" в базе не найдена";
        result.Add(message);
        return result;
      }

      foreach (var car in res.Cars)
      {
        foreach (var driver in car.Drivers)
        {
          Mod mod = new Mod();
          mod.Company = res.Name;
          mod.Car = car.Model;
          mod.Driver = driver.Name;
          result.Add(mod);
        }
      }
      return result;
    }
    //=========   8  +++  ===========================
    public List<Mod> GetAllAboutCompanies(string companyName)
    {
      if (!string.IsNullOrEmpty(companyName))
      {
        List<Mod> result = new List<Mod>();
        var res = _context.Companies.Include(x => x.Cars).ThenInclude(z => z.Drivers).FirstOrDefault(x => x.Name == companyName);
        if (res==null)
        {
          Mod mod = new Mod();
          mod.Message = "Компания с названием " + companyName + " в базе не найдена";
          result.Add(mod);
          return result;
        }
        foreach (var car in res.Cars)
        {
          foreach (var driver in car.Drivers)
          {
            Mod mod = new Mod();
            mod.Company = res.Name;
            mod.Car = car.Model;
            mod.Driver = driver.Name;
            result.Add(mod);
          }
        }
        return result;
      }
      else
      {
        List<Mod> result2 = new List<Mod>();
        var res = _context.Companies.Include(x => x.Cars).ThenInclude(z => z.Drivers).ToList();
        foreach (var com in res)
        {
          foreach (var car in com.Cars)
          {
            foreach (var driver in car.Drivers)
            {
              Mod mod = new Mod();
              mod.Company = com.Name;
              mod.Car = car.Model;
              mod.Driver = driver.Name;
              result2.Add(mod);
            }
          }
        }
        return result2;
      }
    }
    //===============  9  +++    =======================
    public string UpdateOneCarInOneCompany(int? CompanyId, Car car, int? CarId)
    {
      if (CompanyId==null || CarId==null)
      {
        return Messages.ErrorInput();
      }
      var results = new List<ValidationResult>();
      var context = new ValidationContext(car);
      if (!Validator.TryValidateObject(car, context, results, true))
      {
        foreach (var error in results)
        {
          return error.ErrorMessage;
        }
      }
      var com = _context.Companies.FirstOrDefault(z => z.Id == CompanyId);
      if (com==null)
      {
        return Messages.NotFound("Company with Id:",CompanyId);
      }
      var res = _context.Cars.Include(z => z.Company).FirstOrDefault(x => x.Id == CarId);
      if (res == null)
      {
        return Messages.NotFound("Car with Id:", CarId);
      }
      if (res.CompanyId != CompanyId)
      {
        string text = "Автомобиль с Id:" + res.Id +" Модель:"+res.Model + " не пренадлежит компании:"+com.Name+" с Id:"+com.Id ;
        return text;
      }
      res.Model = car.Model;
      _context.Cars.Update(res);
      _context.SaveChanges();
      return Messages.AllOk();

    }
    //==========  10  +++       =====================
    public string UpdateOneDriverInOneCompany(int? CompanyId, Driver driver, int? DriverId)
    {
      if (CompanyId==null || DriverId==null)
      {
        return Messages.ErrorInput();
      }
      var com = _context.Companies.FirstOrDefault(z => z.Id == CompanyId);
      if (com==null)
      {
        return Messages.NotFound("Company with Id",CompanyId);
      }
  
      var res = _context.Drivers.Include(x => x.Cars).ThenInclude(z => z.Company).FirstOrDefault(z => z.Id == DriverId);
      if (res == null)
      {
        return Messages.NotFound("Driver with Id", DriverId);
      }
      if (com.Id != res.Cars[0].CompanyId)
        // пользуйся дебагером и открывай объект
      {
        string text = "Водитель: " + res.Name +" c ID:"+res.Id+ " не работает на компанию :" + com.Name;
        return text;
      }
      res.Name = driver.Name;
      _context.Drivers.Update(res);
      _context.SaveChanges();
      return Messages.AllOk();
    }
  }
}
