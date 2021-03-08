using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Interfacies
{
  public interface IRepository
  {
    /// <summary>
    /// данные о всех компаниях,
    /// данные про определенную компанию по названию компании
    /// </summary>
    /// <param name="search">companyName</param>
    /// <returns></returns>
    List<Mod> GetAllAboutCompanies(string search);
    /// <summary>
    /// данные про компанию по определенному ID
    /// </summary>
    /// <param name="CompanyId"></param>
    /// <returns></returns>
    List<Mod> GetAboutOneCompany(int CompanyId);
    /// <summary>
    /// добавление новой компании
    /// </summary>
    /// <param name="company"></param>
    string AddNewCompany(Company company);
    /// <summary>
    /// добавляет машину в определенную компанию
    /// </summary>
    /// <param name="CompanyId">id компании</param>
    /// <param name="car">модель машины</param>
    string AddNewCarInCompany(int? CompanyId, Car car);

    /// <summary>
    /// Обновляет машину.
    /// Требуется одна машина
    /// </summary>
    /// <param name="CompanyId">ID компании</param>
    /// <param name="car"></param>
    /// <param name="CarId"></param>
    string UpdateOneCarInOneCompany(int? CompanyId, Car car, int? CarId);
    //=======================================
    /// <summary>
    /// добавить водителя в определенную компанию
    /// </summary>
    /// <param name="CompanyId">Id компании </param>
    /// <param name="CarId">Id машины</param>
    /// <param name="driver">данные водителя</param>
    /// <returns></returns>
    string AddNewDriverInOneCompany(int? CompanyId, int? CarId, Driver driver);

    //===================================================
    string UpdateOneDriverInOneCompany(int? CompanyId, Driver driver, int? DriverId);

    string DeleteCompany(int? id);
    string DeleteOneDriverFromCompany(int? CompanyId,int? CarId, int? DriverId);

    string DeleteOneCarFromCompany(int? CompanyId, int? CarId);

  }
}
