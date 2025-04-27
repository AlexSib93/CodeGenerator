using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ProjectFiles.Ts
{
    public class TsClass : IClass, IGenerator
    {
        public ModelMetadata ClassInfo { get; set; }

        public TsClass(ModelMetadata classInfo)
        {
            ClassInfo = classInfo;
        }

        public string Header => $@"{TsPropBuilder.UsingPropTypeText(ClassInfo)}";

        public string Body => $@"export interface {ClassInfo.Name} {{
{GetPropsText}}}

export const init{ClassInfo.Name} = {{
{GetInitValueText}
}}
";

        public string GetPropsText => TsPropBuilder.GetPropsText(ClassInfo);

        public string GetInitValueText => TsPropBuilder.GetInitPropsText(ClassInfo);

        public string Name { get; set; }

        public string Gen()
        {
            return $@"{Header}{Body}";
        }
    }
}
