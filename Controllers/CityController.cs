using Microsoft.AspNetCore.Mvc;
using Dapper_SQL_ASP.NetCore_WebAPI.Model;
using Dapper_SQL_ASP.NetCore_WebAPI.Contracts;


namespace Dapper_SQL_ASP.NetCore_WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CityController : ControllerBase
  {
    [HttpGet]
    public async Task<IResult> GetCities(ICityRepository repository)
    {
      try
      {
        return Results.Ok(await repository.GetCities());
      }
      catch(Exception ex)
      {
        return Results.Problem(ex.Message);
      }
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetCity(int id, ICityRepository repository)
    {
      try
      {
        var city = await repository.GetCity(id);

        if (city == null) 
        { 
          return Results.NotFound();
        }

        return Results.Ok(city);
      }
      catch (Exception ex)
      {
        return Results.Problem(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IResult> AddCity(City city, ICityRepository repository)
    {
      try
      {
        await repository.AddCity(city);
        return Results.Ok();
      }
      catch (Exception ex)
      {
        return Results.Problem(ex.Message);
      }
    }

    [HttpPut("{id}")]
    public async Task<IResult> UpdateCity(City city, ICityRepository repository)
    {
      try
      {
        var OldCity = await repository.GetCity(city.CityId);

        if (OldCity == null)
        {
          return Results.NotFound();
        }

        await repository.UpdateCity(city);

        return Results.Ok();
      }
      catch (Exception ex)
      {
        return Results.Problem(ex.Message);
      }
    }

    [HttpDelete("{id}")]
    public async Task<IResult> DeleteCity(int id, ICityRepository repository)
    {
      try
      {
        var OldCity = await repository.GetCity(id);

        if (OldCity == null)
        {
          return Results.NotFound();
        }

        await repository.DeleteCity(id);

        return Results.Ok();
      }
      catch (Exception ex)
      {
        return Results.Problem(ex.Message);
      }
    }
  }
}
