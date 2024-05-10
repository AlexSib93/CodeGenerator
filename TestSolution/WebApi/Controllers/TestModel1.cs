using BuisinessLogicLayer.Services;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Dto;

namespace TestNamespace
{    
    [Route("api/[controller]")]
    [ApiController]
    public class TestModel1Controller : ControllerBase
    {
        private ITestModel1Service _testModel1Service { get; set; }
        private readonly ILogger<TestModel1Controller> _logger;
        public TestModel1Controller(ILogger<TestModel1Controller> logger, ITestModel1Service testModel1Service)
        {
            _logger = logger;
            _testModel1Service = testModel1Service;
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] TestModel1 testModel1)
        {
            try
            {
                TestModel1 res = _testModel1Service.Add(testModel1);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось создать Тестовая модель 1");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            try
            {
                TestModel1 res = _testModel1Service.Get(id);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось получить Тестовая модель 1");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<TestModel1> res = _testModel1Service.Get();

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось получить все Тестовая модель 1");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _testModel1Service.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось удалить Тестовая модель 1");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

    }
}
