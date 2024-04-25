using BuisinessLogicLayer.Services;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TerminalApi.ViewModels;

namespace TerminalApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IPeoplesService _peoplesService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IPeoplesService peoplesService)
    {
        _logger = logger;
        _peoplesService = peoplesService;
    }

    [HttpGet("get")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("get2")]
    public async Task<ActionResult<PeopleViewModel>> Get2()
    {
        PeopleViewModel resPeople = null;
        try
        {
            var people = _peoplesService.GetByBarcode("456321");
            resPeople = people.Adapt<PeopleViewModel>();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok(resPeople);
    }

    [HttpGet("get3")]
    public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get3()
    {
        return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray());
    }

    [HttpGet("get4")]
    public ActionResult<PeopleViewModel> Get4()
    {
        PeopleViewModel resPeople = null;
        try
        {
            var people = _peoplesService.GetByBarcode("456321");
            resPeople = people.Adapt<PeopleViewModel>();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(resPeople);
    }
}
