using Dapper;
using System.Data;
using System.Data.SqlClient;
using Dapper_SQL_ASP.NetCore_WebAPI.Contracts;

namespace Dapper_SQL_ASP.NetCore_WebAPI.DbAccess
{
  public class SqlDataAccess : ISqlDataAccess
  {
    private readonly IConfiguration _configuration;
    private readonly string? _connectionString;

    public SqlDataAccess(IConfiguration configuration)
    {
      _configuration = configuration;
      _connectionString = _configuration.GetConnectionString("SqlDbConnection");
    }

    public IDbConnection CreateSqlConnection() => new SqlConnection(_connectionString);

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters)
    {
      using IDbConnection dbConnection = new SqlConnection(_connectionString);

      return await dbConnection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storedProcedure, T parameters)
    {
      using IDbConnection dbConnection = new SqlConnection(_connectionString);

      await dbConnection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
  }
}