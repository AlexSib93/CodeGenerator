using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class CsClass : IClass, IGenerator
    {
        public string Name { get; set; }
        public CsClass(ClassMetadata classInfo)
        {
            ClassInfo = classInfo;
        }

        public ClassMetadata ClassInfo { get; set; }

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

        public string Gen()
        {
            return $"{ Header }\n\n{ Body}";
        }
    }
}
