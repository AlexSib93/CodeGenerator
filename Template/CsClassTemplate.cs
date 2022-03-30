using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class CsClassTemplate
    {
        public CsClassTemplate(ClassModelMetaInfo classInfo)
        {
            ClassInfo = classInfo;
        }

        public ClassModelMetaInfo ClassInfo { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"namespace {ClassInfo.NameSpace}
{{
    public class {ClassInfo.ClassModelName}
    {{
{GetPropsText}
    }}
}}
";

        public string GetPropsText => CsPropBuilder.GetPropsText(ClassInfo);

        public string UsingText => $@"using System;";

        public string FileText => $@"{Header}

{Body}";
    }
}
