using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Class
{
    public class CsClassClass : IClass
    {
        public string Name { get; set; }
        public CsClassClass(ClassModelMetaInfo classInfo)
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
