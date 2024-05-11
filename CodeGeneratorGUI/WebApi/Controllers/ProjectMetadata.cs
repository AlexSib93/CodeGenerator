using BuisinessLogicLayer.Services;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Dto;

namespace CodeGeneratorGUI
{    
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectMetadataController : ControllerBase
    {
        private IProjectMetadataService _projectMetadataService { get; set; }
        private readonly ILogger<ProjectMetadataController> _logger;
        public ProjectMetadataController(ILogger<ProjectMetadataController> logger, IProjectMetadataService projectMetadataService)
        {
            _logger = logger;
            _projectMetadataService = projectMetadataService;
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] ProjectMetadata projectMetadata)
        {
            try
            {
                ProjectMetadata res = _projectMetadataService.Add(projectMetadata);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось создать Проект");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            try
            {
                ProjectMetadata res = _projectMetadataService.Get(id);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось получить Проект");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<ProjectMetadata> res = _projectMetadataService.Get();

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось получить все Проект");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _projectMetadataService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось удалить Проект");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

    }
}
