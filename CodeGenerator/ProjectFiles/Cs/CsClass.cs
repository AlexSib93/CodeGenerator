using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ProjectFiles.Cs
{
    public class CsClass : IClass, IGenerator
    {
        public string Name { get; set; }
        public CsClass(ModelMetadata classInfo)
        {
            ClassInfo = classInfo;
        }

        public ModelMetadata ClassInfo { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"namespace DataAccessLayer.Dto
{{
    public class {ClassInfo.Name}
    {{
{GetPropsText}
    }}
}}
";

        public string GetPropsText => CsPropBuilder.GetPropsText(ClassInfo);

        public string UsingText => $@"using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;";

        public string Gen()
        {
            return $"{Header}\n\n{Body}";
        }
    }
}
