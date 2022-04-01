using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.CSharp.Class
{
    public class CsApiClass : IClass
    {
        public string Name { get; set; }
        public CsApiClass(ClassModelMetaInfo classInfo)
        {
            ClassInfo = classInfo;
        }

        public ClassModelMetaInfo ClassInfo { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"namespace {ClassInfo.NameSpace}
{{
    public class {ClassInfo.ModelName}
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
