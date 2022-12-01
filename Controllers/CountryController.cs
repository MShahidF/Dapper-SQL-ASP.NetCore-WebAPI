using Microsoft.AspNetCore.Mvc;
using Dapper_SQL_ASP.NetCore_WebAPI.Model;
using Dapper_SQL_ASP.NetCore_WebAPI.Contracts;

namespace Dapper_SQL_ASP.NetCore_WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CountryController : ControllerBase
  {
    private readonly ICountryRepository _countryRepository;

    public CountryController(ICountryRepository countryRepository)
    {
      _countryRepository = countryRepository;
    }

    [HttpGet]
    public async Task<IResult> GetCountries()
    {
      try
      {
        return Results.Ok(await _countryRepository.GetCountries());
      }
      catch (Exception ex)
      {
        return Results.Problem(ex.Message);
      }
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetCountry(int id)
    {
      try
      {
        var country = await _countryRepository.GetCountry(id);

        if (country is null)
        {
          return Results.NotFound();
        }

        return Results.Ok(country);
      }
      catch (Exception ex)
      {
        return Results.Problem(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IResult> AddCountry(Country country)
    {
      try
      {
        await _countryRepository.AddCountry(country);
        return Results.Ok();
      }
      catch (Exception ex)
      {
        return Results.Problem(ex.Message);
      }
    }

    [HttpPut("{id}")]
    public async Task<IResult> UpdateCountry(int id, Country country)
    {
      try
      {
        var oldCountry = await _countryRepository.GetCountry(id);

        if (oldCountry is null)
        {
          return Results.NotFound();
        }
          
        await _countryRepository.UpdateCountry(id, country);

        return Results.Ok();
      }
      catch (Exception ex)
      {
        return Results.Problem(ex.Message);
      }
    }

    [HttpDelete("{id}")]
    public async Task<IResult> DeleteCountry(int id)
    {
      try
      {
        var oldCountry = await _countryRepository.GetCountry(id);

        if (oldCountry is null)
        {
          return Results.NotFound();
        }

        await _countryRepository.DeleteCountry(id);

        return Results.Ok();
      }
      catch (Exception ex)
      {
        return Results.Problem(ex.Message);
      }
    }
  }
}
