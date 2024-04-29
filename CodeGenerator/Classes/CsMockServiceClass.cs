using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.CSharp.Class
{
    public class CsMockServiceClass : IClass, IGenerator
    {
        public string Name { get; set; }
        public string ParamName => StringHelper.ToLowerFirstChar(ClassInfo.Name);
        public CsMockServiceClass(ModelMetadata classInfo)
        {
            ClassInfo = classInfo;
        }

        public ModelMetadata ClassInfo { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"namespace BuisinessLogicLayer.Services
{{
    public class {ClassInfo.Name}Service : BaseService, I{ClassInfo.Name}Service
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
            string res = $@"        public {ClassInfo.Name}Service(IGenUoW unit) : base(unit)
        {{
        }}";

            return res;
        }

        private string CreateOperationText()
        {
            string res = $@"        public {ClassInfo.Name} Create({ClassInfo.Name} {ParamName})
        {{
            Unit.Rep{ClassInfo.Name}.Create({ParamName});

            return {ParamName};
        }}";

            return res;
        }

        private string GetOperationText()
        {
            string param = ClassInfo.Name.Substring(0,1).ToLower();
            string res = $@"        public {ClassInfo.Name} Get(int id)
        {{
            Unit.Rep{ClassInfo.Name}.Get({param} => {param}.Id{ClassInfo.Name}==id);

            return {param};
        }}";

            return res;
        }

        private string GetAllOperationText()
        {
            string param = ParamName + "s";
            string res = $@"        public List<{ClassInfo.Name}> Get()
        {{
            List<{ClassInfo.Name}> {param} = Unit.Rep{ClassInfo.Name}.Get();

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
using DataAccessLayer.Dto;
using BuisinessLogicLayer.Views;";

    }
}
