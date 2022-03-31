using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class CsServiceTemplate
    {
        public CsServiceTemplate(ClassModelMetaInfo classInfo)
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

        public string GetPropsText => CsPropBuilder.GetPropsText(ClassInfo);

        public string UsingText => $@"using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Dto;";

        public string FileText => $@"{Header}

{Body}";
    }
}
