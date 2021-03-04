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
     var res=MyRepository.GetAboutOneCompany(CompanyId);
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
    public Task InvokeMethod3Async(Company company)
    {
      MyRepository.AddNewCompany(company);
      return Task.CompletedTask;
    }
    //==========================================  ?????????????????
    [JsonRpcMethod("AddNewDriverInOneCompany", "CompanyId", "CarId", "driver")]
    public Task<string>  InvokeMethod4Async(int CompanyId, int CarId, Driver driver)
    {
     var mess= MyRepository.AddNewDriverInOneCompany( CompanyId,  CarId, driver);
      return Task.FromResult(mess);
    }
    //===========================
    [JsonRpcMethod("DeleteCompany", "CompanyId")]
    public Task InvokeMethod5Async(int CompanyId)
    {
      MyRepository.DeleteCompany(CompanyId);
      return Task.CompletedTask;
    }
    //==================================
    [JsonRpcMethod("UpdateOneDriverInOneCompany", "CompanyId", "driver", "DriverId")]
    public Task InvokeMethod6Async(int CompanyId, Driver driver, int DriverId)
    {
      MyRepository.UpdateOneDriverInOneCompany(CompanyId,  driver, DriverId);
      return Task.CompletedTask;
    }
    //====================================================
    [JsonRpcMethod("UpdateOneCarInOneCompany", "CompanyId", "car", "CarId")]
    public Task InvokeMethod7Async(int CompanyId, Car car, int CarId)
    {
      MyRepository.UpdateOneCarInOneCompany(CompanyId, car, CarId);
      return Task.CompletedTask;
    }
    //========================================================
    [JsonRpcMethod("DeleteOneDriverFromCompany", "CompanyId", "CarId", "DriverId")]
    public Task InvokeMethod8Async(int CompanyId, int CarId, int DriverId)
    {
      MyRepository.DeleteOneDriverFromCompany(CompanyId, CarId, DriverId);
      return Task.CompletedTask;
    }
    //===================================================
    [JsonRpcMethod("DeleteOneCarFromCompany", "CompanyId", "CarId")]
    public Task InvokeMethod9Async(int CompanyId, int CarId)
    {
      MyRepository.DeleteOneCarFromCompany(CompanyId, CarId);
      return Task.CompletedTask;
    }
    //=================================================================
    [JsonRpcMethod("AddNewCarInCompany", "CompanyId", "Car")]
    public Task InvokeMethod10Async(int CompanyId, Car car)
    {
      MyRepository.AddNewCarInCompany(CompanyId, car);
      return Task.CompletedTask;
    }
  }
}
