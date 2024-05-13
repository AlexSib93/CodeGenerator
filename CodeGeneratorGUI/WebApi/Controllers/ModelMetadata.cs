using BuisinessLogicLayer.Services;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Dto;

namespace CodeGeneratorGUI
{    
    [Route("api/[controller]")]
    [ApiController]
    public class ModelMetadataController : ControllerBase
    {
        private IModelMetadataService _modelMetadataService { get; set; }
        private readonly ILogger<ModelMetadataController> _logger;
        public ModelMetadataController(ILogger<ModelMetadataController> logger, IModelMetadataService modelMetadataService)
        {
            _logger = logger;
            _modelMetadataService = modelMetadataService;
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] ModelMetadata modelMetadata)
        {
            try
            {
                ModelMetadata res = _modelMetadataService.Add(modelMetadata);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось создать Модель");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            try
            {
                ModelMetadata res = _modelMetadataService.Get(id);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось получить Модель");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            try
            {
                //IEnumerable<ModelMetadata> res = _modelMetadataService.Get();
                string nameSpace = "CodeGeneratorGUI";
                ModelMetadata modelMetadata1 = new ModelMetadata()
                {
                    Name = "ModelMetadata",
                    Caption = "Модель",
                    NameSpace = nameSpace,
                    Props = new List<PropMetadata>() {
                        new PropMetadata()
                        {
                            Name = "Name",
                            Type = "string",
                            Caption = "Имя"
                        },
                        new PropMetadata()
                        {
                            Name =  "Description",
                            Type = "string",
                            Caption = "Описание"
                        },
                        new PropMetadata()
                        {
                            Name =  "Id",
                            Type = "int",
                            Caption = "Идентификатор"
                        }
                    }
                };
                ModelMetadata modelMetadata2 = new ModelMetadata()
                {
                    Name = "ProjectMetadata",
                    Caption = "Проект",
                    NameSpace = nameSpace,
                };
                ModelMetadata modelMetadata3 = new ModelMetadata()
                {
                    Name = "FormMetadata",
                    Caption = "Форма",
                    NameSpace = nameSpace
                };
                IEnumerable<ModelMetadata> res = new List<ModelMetadata> {
                modelMetadata1,
                modelMetadata2,
                modelMetadata3
            };//_modelMetadataService.Get();
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось получить все Модель");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _modelMetadataService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось удалить Модель");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

    }
}
