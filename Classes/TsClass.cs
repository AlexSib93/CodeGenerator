﻿using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class TsClass : IClass, IGenerator
    {
        public ModelMetadata ClassInfo { get; set; }

        public TsClass(ModelMetadata classInfo)
        {
            ClassInfo = classInfo;
        }


        public string Body => $@"export interface {ClassInfo.Name} {{
{GetPropsText}}}

export const initial{ClassInfo.Name} = {{
{GetInitValueText}
}}
";

        public string GetPropsText => TsPropBuilder.GetPropsText(ClassInfo);

        public string GetInitValueText => TsPropBuilder.GetInitPropsText(ClassInfo);

        public string Name { get; set; }

        public string Gen()
        {
            return $@"{Body}";
        }
    }
}
