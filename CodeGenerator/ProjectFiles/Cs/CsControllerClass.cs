using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ProjectFiles.Cs
{
    public class CsControllerClass : IClass, IGenerator
    {
        public string Name { get; set; }
        public string ParamName => StringHelper.ToLowerFirstChar(ClassInfo.Name);
        public CsControllerClass(ModelMetadata classInfo)
        {
            ClassInfo = classInfo;
        }

        public ModelMetadata ClassInfo { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"namespace {ClassInfo.NameSpace}
{{    
    [Route(""api/[controller]"")]
    [ApiController]
    public class {ClassInfo.Name}Controller : ControllerBase
    {{
{GetPropsText}
{GetConstructorText()}

{CreateOperationText()}

{UpdateOperationText()}

{GetOperationText()}

{GetAllOperationText()}

{DeleteOperationText()}

    }}
}}
";

        private string CreateOperationText()
        {
            return $@"        /// <summary>
        /// Создать '{ClassInfo.Caption}'
        /// </summary>
        /// <returns></returns>
        [HttpPost(""create"")]
        public IActionResult Create([FromBody] {ClassInfo.Name} {ParamName})
        {{
            try
            {{
                {ClassInfo.Name} res = _{ParamName}Service.Add({ParamName});

                return Ok(res);
            }}
            catch (Exception ex)
            {{
                _logger.LogError(ex, ""Не удалось создать {ClassInfo.Caption}"");
                return BadRequest(ex.Message + "" "" + ex.InnerException?.Message);
            }}
        }}";
        }

        private string UpdateOperationText()
        {
            return $@"        /// <summary>
        /// Удалить сущность '{ClassInfo.Caption}' по ID
        /// </summary>
        /// <param name=""id"">ID сущности</param>
        /// <returns></returns>
        [HttpPut(""put"")]
        public IActionResult Put([FromBody] {ClassInfo.Name} {ParamName})
        {{
            try
            {{
                {ClassInfo.Name} res = _{ParamName}Service.Update({ParamName});

                return Ok(res);
            }}
            catch (Exception ex)
            {{
                return BadRequest(ex.Message + "" "" + ex.InnerException?.Message);
            }}
        }}";
        }

        private string GetOperationText()
        {
            return $@"        /// <summary>
        /// Получить сущность '{ClassInfo.Caption}' по ID
        /// </summary>
        /// <param name=""id"">ID сущности</param>
        /// <returns></returns>
        [HttpGet(""get"")]
        public IActionResult Get(int id)
        {{
            try
            {{
                {ClassInfo.Name} res = _{ParamName}Service.Get(p => p.{ClassInfo.Props.FirstOrDefault(p => p.IsPrimaryKey)?.Name}==id);

                return Ok(res);
            }}
            catch (Exception ex)
            {{
                _logger.LogError(ex, ""Не удалось получить {ClassInfo.Caption}"");
                return BadRequest(ex.Message + "" "" + ex.InnerException?.Message);
            }}
        }}";
        }

        private string GetAllOperationText()
        {
            return $@"        /// <summary>
        /// Получить все сущности '{ClassInfo.Caption}' 
        /// </summary>
        /// <returns></returns>
        [HttpGet(""getall"")]
        public IActionResult GetAll()
        {{
            try
            {{
                IEnumerable<{ClassInfo.Name}> res = _{ParamName}Service.GetAll();

                return Ok(res);
            }}
            catch (Exception ex)
            {{
                _logger.LogError(ex, ""Не удалось получить все {ClassInfo.Caption}"");
                return BadRequest(ex.Message + "" "" + ex.InnerException?.Message);
            }}
        }}";
        }

        private string DeleteOperationText()
        {
            return $@"        /// <summary>
        /// Удалить сущность '{ClassInfo.Caption}' по ID
        /// </summary>
        /// <param name=""id"">ID сущности</param>
        /// <returns></returns>
        [HttpDelete(""delete"")]
        public IActionResult Delete(int id)
        {{
            try
            {{
                _{ParamName}Service.Delete(id);

                return Ok();
            }}
            catch (Exception ex)
            {{
                _logger.LogError(ex, ""Не удалось удалить {ClassInfo.Caption}"");
                return BadRequest(ex.Message + "" "" + ex.InnerException?.Message);
            }}
        }}";
        }


        public string GetPropsText => $@"        private I{ClassInfo.Name}Service _{ParamName}Service {{ get; set; }}
        private readonly ILogger<{ClassInfo.Name}Controller> _logger;";

        private string GetConstructorText()
        {
            string res = $@"        public {ClassInfo.Name}Controller(ILogger<{ClassInfo.Name}Controller> logger, I{ClassInfo.Name}Service {ParamName}Service)
        {{
            _logger = logger;
            _{ParamName}Service = {ParamName}Service;
        }}
";

            return res;
        }
        public string UsingText => $@"using BuisinessLogicLayer.Services;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Dto;";

        public string Gen()
        {
            return $"{Header}\n\n{Body}";
        }
    }

}

