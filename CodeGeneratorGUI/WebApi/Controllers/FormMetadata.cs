using BuisinessLogicLayer.Services;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Dto;

namespace CodeGeneratorGUI
{    
    [Route("api/[controller]")]
    [ApiController]
    public class FormMetadataController : ControllerBase
    {
        private IFormMetadataService _formMetadataService { get; set; }
        private readonly ILogger<FormMetadataController> _logger;
        public FormMetadataController(ILogger<FormMetadataController> logger, IFormMetadataService formMetadataService)
        {
            _logger = logger;
            _formMetadataService = formMetadataService;
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] FormMetadata formMetadata)
        {
            try
            {
                FormMetadata res = _formMetadataService.Add(formMetadata);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось создать Форма");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            try
            {
                FormMetadata res = _formMetadataService.Get(id);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось получить Форма");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<FormMetadata> res = _formMetadataService.Get();

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось получить все Форма");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _formMetadataService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось удалить Форма");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

    }
}
