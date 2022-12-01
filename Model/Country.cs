namespace Dapper_SQL_ASP.NetCore_WebAPI.Model
{
  public class Country
  {
    public int CountryId { get; set; }
    public string CountryName { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
  }
}