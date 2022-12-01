using Dapper_SQL_ASP.NetCore_WebAPI.Model;

namespace Dapper_SQL_ASP.NetCore_WebAPI.Contracts
{
  public interface ICountryRepository
  {
    Task<IEnumerable<Country>> GetCountries();
    Task<Country> GetCountry(int id);
    Task<Country> AddCountry(Country country);
    Task UpdateCountry(int id, Country country);
    Task DeleteCountry(int id);
  }
}