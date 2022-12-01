namespace Dapper_SQL_ASP.NetCore_WebAPI.Model
{
  public class City
  {
    public int CityId { get; set; }
    public string CityName { get; set; } = string.Empty;
    public string CityCode { get; set; } = string.Empty;
    public int CountryId { get; set; }
  }
}
