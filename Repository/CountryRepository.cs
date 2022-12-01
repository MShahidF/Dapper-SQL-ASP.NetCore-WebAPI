using Dapper;
using System.Data;
using Dapper_SQL_ASP.NetCore_WebAPI.Model;
using Dapper_SQL_ASP.NetCore_WebAPI.DbAccess;
using Dapper_SQL_ASP.NetCore_WebAPI.Contracts;

namespace Dapper_SQL_ASP.NetCore_WebAPI.Repository
{
  public class CountryRepository : ICountryRepository
  {
    private readonly SqlDataAccess _sqlDataAccess;

    public CountryRepository(SqlDataAccess sqlDataAccess)
    {
      _sqlDataAccess = sqlDataAccess;
    }

    public async Task<IEnumerable<Country>> GetCountries()
    {
      var query = "SELECT * FROM COUNTRY";

      using (var connection = _sqlDataAccess.CreateSqlConnection())
      {
        var countries = await connection.QueryAsync<Country>(query);
        return countries.ToList();
      }
    }

    public async Task<Country> GetCountry(int id)
    {
      var query = "SELECT * FROM COUNTRY WHERE COUNTRYID = @CountryId";

      using (var connection = _sqlDataAccess.CreateSqlConnection())
      {
        var country = await connection.QuerySingleOrDefaultAsync<Country>(query, new { CountryId = id });
        return country;
      }
    }

    public async Task<Country> AddCountry(Country country)
    {
      var query = "INSERT INTO COUNTRY (CountryId, CountryName, CountryCode) VALUES (@CountryId, @CountryName, @CountryCode)";

      var parameters = new DynamicParameters();
      parameters.Add("CountryId", country.CountryId, DbType.Int32);
      parameters.Add("CountryName", country.CountryName, DbType.String);
      parameters.Add("CountryCode", country.CountryCode, DbType.String);

      using (var connection = _sqlDataAccess.CreateSqlConnection())
      {
        var newCountry = await connection.QuerySingleAsync(query, parameters);
        return newCountry;
      }
    }

    public async Task UpdateCountry(int id, Country country)
    {
      var query = "UPDATE COUNTRY SET CountryName = @CountryName, CountryCode = @CountryCode WHERE CountryId = @CountryId";

      var parameters = new DynamicParameters();
      parameters.Add("CountryId", id, DbType.Int32);
      parameters.Add("CountryName", country.CountryName, DbType.String);
      parameters.Add("CountryCode", country.CountryCode, DbType.String);
      
      using (var connection = _sqlDataAccess.CreateSqlConnection())
      {
        await connection.ExecuteAsync(query, parameters);
      }
    }

    public async Task DeleteCountry(int id)
    {
      var query = "DELETE FROM COUNTRY WHERE CountryId = @CountryId";

      using (var connection = _sqlDataAccess.CreateSqlConnection())
      {
        await connection.ExecuteAsync(query, new { CountryId = id });
      }
    }
  }
}