using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.CSharp.Class
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

{GetOperationText()}

{DeleteOperationText()}

    }}
}}
";

        private string CreateOperationText()
        {
            return $@"        [HttpPost(""create"")]
        public IActionResult Create([FromBody] {ClassInfo.Name} {ParamName})
        {{
            try
            {{
                {ClassInfo.Name} res = _{ParamName}Service.Create({ParamName});

                return Ok(res);
            }}
            catch (Exception ex)
            {{
                _logger.LogError(ex, ""Не удалось создать {ClassInfo.Caption}"");
                return BadRequest(ex.Message + "" "" + ex.InnerException?.Message);
            }}
        }}";
        }

        private string GetOperationText()
        {
            return $@"        [HttpGet(""get"")]
        public IActionResult Get(int id)
        {{
            try
            {{
                {ClassInfo.Name} res = _{ParamName}Service.Get(id);

                return Ok(res);
            }}
            catch (Exception ex)
            {{
                _logger.LogError(ex, ""Не удалось создать {ClassInfo.Caption}"");
                return BadRequest(ex.Message + "" "" + ex.InnerException?.Message);
            }}
        }}";
        }

        private string DeleteOperationText()
        {
            return $@"        [HttpDelete(""delete"")]
        public IActionResult Delete(int id)
        {{
            try
            {{
                {ClassInfo.Name} res = _{ParamName}Service.Delete(id);

                return Ok(res);
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
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortalApi.ViewModels;
using DataAccessLayer.Dto;";

        public string Gen()
        {
            return $"{Header}\n\n{Body}";
        }
    }

}

