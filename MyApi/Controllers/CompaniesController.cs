using Microsoft.AspNetCore.Mvc;
using MyApi.Interfacies;
using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CompaniesController : ControllerBase
  {
    public IRepository MyRepository;

    public CompaniesController(IRepository Repository)
    {
      MyRepository =Repository;
    }
    //    1   ----------!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //GET: api/<CompaniesController>
    [HttpGet]
    // public async Task<ActionResult<IEnumerable<Car>>> Get(string search)
    public async Task<ActionResult<List<Mod>>> Get(string search=null)
    {
      return MyRepository.GetAllAboutCompanies(search);
    }
//     2       !!!!!!!!!!!!!!!!!!!!!!!!!!!!
    [HttpGet("{id}")]
    public List<Mod> GetOneCompany(int id)
    {
      return MyRepository.GetAboutOneCompany(id);
    }
//    3  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    [HttpDelete("{id}")]
    public void DeleteCompany(int id)
    {
      MyRepository.DeleteCompany(id);
    }
//  4    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    [HttpPost]
    public void AddCompany(Company company)
    {
      MyRepository.AddNewCompany(company);
    }
    //   5  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    [HttpPost("{CompanyId}")]
    public void AddNewCarCompany(int CompanyId, Car car)
    {
      MyRepository.AddNewCarInCompany(CompanyId, car);
    }
    //=    6  ========  !!!!!!!!!!!!!!!!  ????????????????  ====================================
    [HttpPost("{CompanyId}/{CarId}/drivers")]
    public string AddNewDriverCompany(int CompanyId, int CarId, Driver driver)
     // public void AddNewDriverCompany(int CompanyId, int CarId, Driver driver)
    {
     return MyRepository.AddNewDriverInOneCompany(CompanyId, CarId, driver);
      // MyRepository.AddNewDriverInOneCompany(CompanyId, CarId, driver);
    }
    //=================================================
    //   7    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    [HttpDelete("{CompanyId}/{CarId}")]
    public void DeleteOneCarFromCompany(int CompanyId, int CarId)
    {
      MyRepository.DeleteOneCarFromCompany(CompanyId, CarId);
    }
//   8     !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    [HttpPost("{CompanyId}/{CarId}")]
    public void UpdateOneCarInOneCompany(int CompanyId, Car car, int CarId)
    {
      MyRepository.UpdateOneCarInOneCompany(CompanyId, car, CarId);
    }
//======   9     !!!!!!    ==============================================
    [HttpDelete("{CompanyId}/{CarId}/{DriverId}")]
    public void DeleteOneDriverFromCompany(int CompanyId, int CarId,int DriverId)
    {
      MyRepository.DeleteOneDriverFromCompany(CompanyId, CarId, DriverId);
    }

    [HttpPost("{CompanyId}/{DriverId}/updatedriver")]
    public void UpdateOneDriverInOneCompany(int CompanyId,int DriverId,Driver driver)
    {
      MyRepository.UpdateOneDriverInOneCompany(CompanyId, driver, DriverId );
    }
  }
}
