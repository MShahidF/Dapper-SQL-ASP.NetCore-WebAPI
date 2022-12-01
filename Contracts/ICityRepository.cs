using Dapper_SQL_ASP.NetCore_WebAPI.Model;

namespace Dapper_SQL_ASP.NetCore_WebAPI.Contracts
{
  public interface ICityRepository
  {
    Task<IEnumerable<City>> GetCities();
    Task<City> GetCity(int id);
    Task AddCity(City city);
    Task UpdateCity(City city);
    Task DeleteCity(int id);
  }
}
