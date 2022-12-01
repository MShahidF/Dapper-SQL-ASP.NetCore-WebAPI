using Dapper_SQL_ASP.NetCore_WebAPI.Model;
using Dapper_SQL_ASP.NetCore_WebAPI.DbAccess;
using Dapper_SQL_ASP.NetCore_WebAPI.Contracts;

namespace Dapper_SQL_ASP.NetCore_WebAPI.Repository
{
  public class CityRepository : ICityRepository
  {
    private readonly SqlDataAccess _sqlDataAccess;

    public CityRepository(SqlDataAccess sqlDataAccess)
    {
      _sqlDataAccess = sqlDataAccess;
    }

    public Task<IEnumerable<City>> GetCities() => _sqlDataAccess.LoadData<City, dynamic>("CITY_GET_ALL", new { });

    public async Task<City> GetCity(int id)
    {
      var results = await _sqlDataAccess.LoadData<City, dynamic>("CITY_GET", new { CityId = id });

      return results.FirstOrDefault();
    }

    public Task AddCity(City city) => _sqlDataAccess.SaveData("CITY_ADD", new { city.CityId, city.CityName, city.CityCode, city.CountryId });

    public Task UpdateCity(City city) => _sqlDataAccess.SaveData("CITY_UPDATE", city);

    public Task DeleteCity(int id) => _sqlDataAccess.SaveData("CITY_DELETE", new { CityId = id });
  }
} 