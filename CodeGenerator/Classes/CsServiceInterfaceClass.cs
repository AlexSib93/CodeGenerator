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
        public string ParamName => StringHelper.ToLowerFirstChar(ClassInfo.Name);
        public CsServiceInterfaceClass(ModelMetadata classInfo)
        {
            ClassInfo = classInfo;
        }

        public ModelMetadata ClassInfo { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"namespace BuisinessLogicLayer.Services
{{
    public interface I{ClassInfo.Name}Service
    {{

{CreateOperationText()}

{GetOperationText()}

{GetAllOperationText()}
    }}
}}
";


        private string CreateOperationText()
        {
            string res = $@"        {ClassInfo.Name} Create({ClassInfo.Name} {ParamName});";

            return res;
        }

        private string GetOperationText()
        {
            string param = ClassInfo.Name.Substring(0,1).ToLower();
            string res = $@"        {ClassInfo.Name} Get(int id);";

            return res;
        }

        private string GetAllOperationText()
        {
            string param = ParamName + "s";
            string res = $@"        List<{ClassInfo.Name}> Get();";

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
