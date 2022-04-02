using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.CSharp.Class
{
    public class CsServiceClass : IClass, IGenerator
    {
        public string Name { get; set; }
        public string ParamName => StringHelper.ToLowerFirstChar(ClassInfo.ModelName);
        public CsServiceClass(ClassMetadata classInfo)
        {
            ClassInfo = classInfo;
        }

        public ClassMetadata ClassInfo { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"namespace BuisinessLogicLayer.Services
{{
    public class {ClassInfo.ModelName}Service : BaseService, I{ClassInfo.ModelName}Service
    {{
{GetConstructorText()}

{CreateOperationText()}

{GetOperationText()}

{GetAllOperationText()}
    }}
}}
";

        private string GetConstructorText()
        {
            string res = $@"        public {ClassInfo.ModelName}Service(IGenUoW unit) : base(unit)
        {{
        }}";

            return res;
        }

        private string CreateOperationText()
        {
            string res = $@"        public {ClassInfo.ModelName} Create({ClassInfo.ModelName} {ParamName})
        {{
            Unit.Rep{ClassInfo.ModelName}.Create({ParamName});

            return {ParamName};
        }}";

            return res;
        }

        private string GetOperationText()
        {
            string param = ClassInfo.ModelName.Substring(0,1).ToLower();
            string res = $@"        public {ClassInfo.ModelName} Get(int id)
        {{
            Unit.Rep{ClassInfo.ModelName}.Get({param} => {param}.Id{ClassInfo.ModelName}==id);

            return {param};
        }}";

            return res;
        }

        private string GetAllOperationText()
        {
            string param = ParamName + "s";
            string res = $@"        public List<{ClassInfo.ModelName}> Get()
        {{
            List<{ClassInfo.ModelName}> {param} = Unit.Rep{ClassInfo.ModelName}.Get();

            return {param};
        }}";

            return res;
        }

        public string Gen()
        {
            return $"{ Header}\n\n{ Body}";
        }

        public string UsingText => $@"using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Dto;";

    }
}
