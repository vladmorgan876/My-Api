using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Interfacies
{
  public interface IRepository
  {
    List<Car> GetAllAboutCompanies();
    Company GetAboutOneCompany(int CompanyId);
    void AddNewCompany(Company company);

    void AddNewCarInCompany(int CompanyId, Car car);

    /// <summary>
    /// Обновляет машину.
    /// Требуется одна машина
    /// </summary>
    /// <param name="CompanyId">ID компании</param>
    /// <param name="car"></param>
    /// <param name="CarId"></param>
    void UpdateOneCarInOneCompany(int CompanyId, Car car, int CarId);
//=======================================
    void AddNewDriverInOneCompany(int CompanyId, int CarId, Driver driver);
//===================================================
    void UpdateOneDriverInOneCompany(int CompanyId, Driver driver, int DriverId);

    void DeleteCompany(int id);
    void DeleteOneDriverFromCompany(int CompanyId,int CarId, int DriverId);

    void DeleteOneCarFromCompany(int CompanyId, int CarId);

  }
}
