using Anemonis.AspNetCore.JsonRpc;
using MyApi.Interfacies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models
{
  [JsonRpcRoute("/api")]
  public class JsonRpcServiceI : IJsonRpcService
  {
    public IRepository MyRepository;

    public JsonRpcServiceI(IRepository Repository)
    {
      MyRepository = Repository;
    }
    //=========================================================
    [JsonRpcMethod("GetAboutOneCompany", "CompanyId")]
    public Task<List<Mod>> InvokeMethod1Async(int CompanyId)
    {
      var res = MyRepository.GetAboutOneCompany(CompanyId);
      return Task.FromResult(res);
    }
    //======================================================================
    [JsonRpcMethod("GetAllAboutCompanies", "companyName")]
    public Task<List<Mod>> InvokeMethod2Async(string companyName)
    {
      var res = MyRepository.GetAllAboutCompanies(companyName);
      return Task.FromResult(res);
    }
    //=====================================================
    [JsonRpcMethod("AddNewCompany", "company")]
    public Task<string> InvokeMethod3Async(Company company)
    {
     var mess= MyRepository.AddNewCompany(company);
      return Task.FromResult(mess);
    }
    //==========================================  ?????????????????
    [JsonRpcMethod("AddNewDriverInOneCompany", "CompanyId", "CarId", "driver")]
    public Task<string> InvokeMethod4Async(int? CompanyId, int? CarId, Driver driver)
    {
      var mess = MyRepository.AddNewDriverInOneCompany(CompanyId, CarId, driver);
      return Task.FromResult(mess);
    }
    //===========================
    [JsonRpcMethod("DeleteCompany", "CompanyId")]
    public Task<string> InvokeMethod5Async(int? CompanyId)
    {
      //try
      //{
        var mess = MyRepository.DeleteCompany(CompanyId);
        return Task.FromResult(mess);
      //}
      //catch (ArgumentNullException ex)
      //{
      //  throw new JsonRpcServiceException(4000, ex.Message);
      //}
    }
    //==================================
    [JsonRpcMethod("UpdateOneDriverInOneCompany", "CompanyId", "driver", "DriverId")]
    public Task<string> InvokeMethod6Async(int? CompanyId, Driver driver, int? DriverId)
    {
     var mess= MyRepository.UpdateOneDriverInOneCompany(CompanyId, driver, DriverId);
      return Task.FromResult(mess);
    }
    //====================================================
    [JsonRpcMethod("UpdateOneCarInOneCompany", "CompanyId", "car", "CarId")]
    public Task<string> InvokeMethod7Async(int? CompanyId, Car car, int? CarId)
    {
      var mess=MyRepository.UpdateOneCarInOneCompany(CompanyId, car, CarId);
      return Task.FromResult(mess);
    }
    //========================================================
    [JsonRpcMethod("DeleteOneDriverFromCompany", "CompanyId", "CarId", "DriverId")]
    public Task<string> InvokeMethod8Async(int? CompanyId, int? CarId, int? DriverId)
    {
      var mess=MyRepository.DeleteOneDriverFromCompany(CompanyId, CarId, DriverId);
      return Task.FromResult(mess);
    }
    //===================================================
    [JsonRpcMethod("DeleteOneCarFromCompany", "CompanyId", "CarId")]
    public Task<string> InvokeMethod9Async(int? CompanyId, int? CarId)
    {
      var mess=MyRepository.DeleteOneCarFromCompany(CompanyId, CarId);
      return Task.FromResult(mess);
    }
    //=================================================================
    [JsonRpcMethod("AddNewCarInCompany", "CompanyId", "Car")]
    public Task<string> InvokeMethod10Async(int? CompanyId, Car car)
    {
     var mess= MyRepository.AddNewCarInCompany(CompanyId, car);
      return Task.FromResult(mess);
    }
  }
}
