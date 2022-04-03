using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.CSharp.Class
{
    public class CsServiceInterfaceClass : IClass, IGenerator
    {
        public string Name { get; set; }
        public string ParamName => StringHelper.ToLowerFirstChar(ClassInfo.ModelName);
        public CsServiceInterfaceClass(ClassMetadata classInfo)
        {
            ClassInfo = classInfo;
        }

        public ClassMetadata ClassInfo { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"namespace BuisinessLogicLayer.Services
{{
    public interface I{ClassInfo.ModelName}Service
    {{

{CreateOperationText()}

{GetOperationText()}

{GetAllOperationText()}
    }}
}}
";


        private string CreateOperationText()
        {
            string res = $@"        {ClassInfo.ModelName} Create({ClassInfo.ModelName} {ParamName});";

            return res;
        }

        private string GetOperationText()
        {
            string param = ClassInfo.ModelName.Substring(0,1).ToLower();
            string res = $@"        {ClassInfo.ModelName} Get(int id);";

            return res;
        }

        private string GetAllOperationText()
        {
            string param = ParamName + "s";
            string res = $@"        List<{ClassInfo.ModelName}> Get();";

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
