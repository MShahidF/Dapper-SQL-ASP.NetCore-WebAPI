namespace Dapper_SQL_ASP.NetCore_WebAPI.Contracts
{
  public interface ISqlDataAccess
  {
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters);
    Task SaveData<T>(string storedProcedure, T parameters);
  }
}