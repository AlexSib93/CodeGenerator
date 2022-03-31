using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class TsClassTemplate
    {
        public ClassModelMetaInfo ClassInfo { get; set; }

        public TsClassTemplate(ClassModelMetaInfo classInfo)
        {
            ClassInfo = classInfo;
        }


        public string Body => $@"export interface {ClassInfo.ClassModelName} {{
{GetPropsText}}}
";

        public string GetPropsText => TsPropBuilder.GetPropsText(ClassInfo);

        public string FileText => $@"{Body}";
    }
}
