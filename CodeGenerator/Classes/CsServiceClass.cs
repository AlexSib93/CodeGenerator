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
        public string ParamName => StringHelper.ToLowerFirstChar(ClassInfo.Name);
        public CsServiceClass(ModelMetadata classInfo)
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

{DeleteOperationText()}
    }}
}}
";

        private string GetConstructorText()
        {
            string res = $@"        public {ClassInfo.Name}Service(IUnitOfWork unit) : base(unit)
        {{
        }}";

            return res;
        }

        private string CreateOperationText()
        {
            string res = $@"        public {ClassInfo.Name} Add({ClassInfo.Name} {ParamName})
        {{
            Unit.Rep{ClassInfo.Name}.Add({ParamName});

            return {ParamName};
        }}";

            return res;
        }

        private string GetOperationText()
        {
            string param = ClassInfo.Name.Substring(0,1).ToLower();
            string res = $@"        public {ClassInfo.Name} Get(int id)
        {{
            {ClassInfo.Name} t = Unit.Rep{ClassInfo.Name}.GetById(id);

            return {param};
        }}";

            return res;
        }

        private string DeleteOperationText()
        {
            string param = ClassInfo.Name.Substring(0, 1).ToLower();
            string res = $@"        public void Delete(int id)
        {{
            Unit.Rep{ClassInfo.Name}.Delete(id);
        }}";

            return res;
        }

        private string GetAllOperationText()
        {
            string param = ParamName + "s";
            string res = $@"        public IEnumerable<{ClassInfo.Name}> Get()
        {{
            IEnumerable<{ClassInfo.Name}> {param} = Unit.Rep{ClassInfo.Name}.GetAll();

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
