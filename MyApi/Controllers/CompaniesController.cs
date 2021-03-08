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
    public string DeleteCompany(int? id)
    {
     return MyRepository.DeleteCompany(id);
    }
//  4    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    [HttpPost]
    public string AddCompany(Company company)
    {
     return MyRepository.AddNewCompany(company);
    }
    //   5  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    [HttpPost("{CompanyId}")]
    public string AddNewCarCompany(int? CompanyId, Car car)
    {
     return MyRepository.AddNewCarInCompany(CompanyId, car);
      
    }
    //=    6  ========  !!!!!!!!!!!!!!!!  ????????????????  ====================================
    [HttpPost("{CompanyId}/{CarId}/drivers")]
    public string AddNewDriverCompany(int? CompanyId, int? CarId, Driver driver)
    {
     return MyRepository.AddNewDriverInOneCompany(CompanyId, CarId, driver);
     
    }
    //=================================================
    //   7    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    [HttpDelete("{CompanyId}/{CarId}")]
    public string DeleteOneCarFromCompany(int? CompanyId, int? CarId)
    {
      return MyRepository.DeleteOneCarFromCompany(CompanyId, CarId);
    }
//   8     !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    [HttpPost("{CompanyId}/{CarId}")]
    public string UpdateOneCarInOneCompany(int? CompanyId, Car car, int? CarId)
    {
      return MyRepository.UpdateOneCarInOneCompany(CompanyId, car, CarId);
    }
//======   9     !!!!!!    ==============================================
    [HttpDelete("{CompanyId}/{CarId}/{DriverId}")]
    public string DeleteOneDriverFromCompany(int? CompanyId, int? CarId,int? DriverId)
    {
      return MyRepository.DeleteOneDriverFromCompany(CompanyId, CarId, DriverId);
    }

    [HttpPost("{CompanyId}/{DriverId}/updatedriver")]
    public string UpdateOneDriverInOneCompany(int? CompanyId,int? DriverId,Driver driver)
    {
     return MyRepository.UpdateOneDriverInOneCompany(CompanyId, driver, DriverId );
    }
  }
}
