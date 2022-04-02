using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class TsClass : IClass
    {
        public ClassModelMetaInfo ClassInfo { get; set; }

        public TsClass(ClassModelMetaInfo classInfo)
        {
            ClassInfo = classInfo;
        }


        public string Body => $@"export interface {ClassInfo.ModelName} {{
{GetPropsText}}}

export const initial{ClassInfo.ModelName} = {{
{GetInitValueText}
}}
";

        public string GetPropsText => TsPropBuilder.GetPropsText(ClassInfo);

        public string GetInitValueText => TsPropBuilder.GetInitPropsText(ClassInfo);

        public string FileText => $@"{Body}";

        public string Name { get; set; }
    }
}
