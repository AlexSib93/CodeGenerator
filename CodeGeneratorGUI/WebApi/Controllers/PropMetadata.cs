using BuisinessLogicLayer.Services;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Dto;

namespace CodeGeneratorGUI
{    
    [Route("api/[controller]")]
    [ApiController]
    public class PropMetadataController : ControllerBase
    {
        private IPropMetadataService _propMetadataService { get; set; }
        private readonly ILogger<PropMetadataController> _logger;
        public PropMetadataController(ILogger<PropMetadataController> logger, IPropMetadataService propMetadataService)
        {
            _logger = logger;
            _propMetadataService = propMetadataService;
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] PropMetadata propMetadata)
        {
            try
            {
                PropMetadata res = _propMetadataService.Add(propMetadata);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось создать Свойство");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            try
            {
                PropMetadata res = _propMetadataService.Get(id);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось получить Свойство");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<PropMetadata> res = _propMetadataService.Get();

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось получить все Свойство");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _propMetadataService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось удалить Свойство");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

    }
}
