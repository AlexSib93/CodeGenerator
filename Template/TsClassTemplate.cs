using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class TsClassTemplate
    {
        public TsClassTemplate(ClassModelMetaInfo classInfo)
        {
            ClassInfo = classInfo;
        }

        public ClassModelMetaInfo ClassInfo { get; set; }

        public string Body => $@"export interface {ClassInfo.ClassModelName} {{
{GetPropsText}}}
";

        public string GetPropsText => TsPropBuilder.GetPropsText(ClassInfo);

        public string FileText => $@"{Body}";
    }
}
