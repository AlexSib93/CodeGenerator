using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.CSharp.Class
{
    public class CsServiceClass : IClass
    {
        public string Name { get; set; }
        public CsServiceClass(ClassModelMetaInfo classInfo)
        {
            ClassInfo = classInfo;
        }

        public ClassModelMetaInfo ClassInfo { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"namespace BuisinessLogicLayer.Services
{{
    public class {ClassInfo.ClassModelName}Service : BaseService, I{ClassInfo.ClassModelName}Service
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
            string res = $@"        public {ClassInfo.ClassModelName}Service(IGenUoW unit) : base(unit)
        {{
        }}";

            return res;
        }

        private string CreateOperationText()
        {
            string param = StringHelper.ToLowerFirstChar(ClassInfo.ClassModelName);
            string res = $@"        public {ClassInfo.ClassModelName} Create({ClassInfo.ClassModelName} {param})
        {{
            Unit.Rep{ClassInfo.ClassModelName}.Create({param});

            return {param};
        }}";

            return res;
        }

        private string GetOperationText()
        {
            string param = ClassInfo.ClassModelName.Substring(0,1).ToLower();
            string res = $@"        public {ClassInfo.ClassModelName} Get(int id)
        {{
            Unit.Rep{ClassInfo.ClassModelName}.Get({param} => {param}.Id{ClassInfo.ClassModelName}==id);

            return {param};
        }}";

            return res;
        }

        private string GetAllOperationText()
        {
            string param = StringHelper.ToLowerFirstChar(ClassInfo.ClassModelName) + "s";
            string res = $@"        public List<{ClassInfo.ClassModelName}> Get()
        {{
            List<{ClassInfo.ClassModelName}> {param} = Unit.Rep{ClassInfo.ClassModelName}.Get();

            return {param};
        }}";

            return res;
        }

        public string GetPropsText => CsPropBuilder.GetPropsText(ClassInfo);

        public string UsingText => $@"using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Dto;";

        public string FileText => $@"{Header}

{Body}";

    }
}
