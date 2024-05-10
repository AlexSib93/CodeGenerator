using BuisinessLogicLayer.Services;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Dto;

namespace TestNamespace
{    
    [Route("api/[controller]")]
    [ApiController]
    public class DebugUnitController : ControllerBase
    {
        private IDebugUnitService _debugUnitService { get; set; }
        private readonly ILogger<DebugUnitController> _logger;
        public DebugUnitController(ILogger<DebugUnitController> logger, IDebugUnitService debugUnitService)
        {
            _logger = logger;
            _debugUnitService = debugUnitService;
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] DebugUnit debugUnit)
        {
            try
            {
                DebugUnit res = _debugUnitService.Add(debugUnit);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось создать Едиица отладки");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            try
            {
                DebugUnit res = _debugUnitService.Get(id);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось получить Едиица отладки");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<DebugUnit> res = _debugUnitService.Get();

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось получить все Едиица отладки");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _debugUnitService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось удалить Едиица отладки");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

    }
}
