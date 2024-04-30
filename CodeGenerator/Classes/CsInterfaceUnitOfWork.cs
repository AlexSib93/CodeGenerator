﻿using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class CsInterfaceUnitOfWork : IClass, IGenerator
    {
        public string Name { get; set; }
        public CsInterfaceUnitOfWork(List<ModelMetadata> models)
        {
            Models = models;
        }

        public ModelMetadata ClassInfo { get; set; }
        public List<ModelMetadata> Models { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"namespace DataAccessLayer
{{
    public interface IUnitOfWork : IDisposable
    {{
{GetModelsText(Models)}

    }}
}}
";

        public string UsingText => $@"using System;
using DataAccessLayer.Dto;";

        public string GetModelText(ModelMetadata classInfo)
        {
            string res = "";
            res += $@"
        IRepository<{classInfo.Name}> Rep{classInfo.Name} {{ get;}}";

            return res;
        }

        public string GetModelsText(List<ModelMetadata> classesInfo)
        {
            string res = "";
            foreach (ModelMetadata classInfo in classesInfo)
            {
                res += $"{GetModelText(classInfo)}\n";

            }


            return res;
        }
        public string Gen()
        {
            return $"{ Header }\n\n{ Body}";
        }

    }
}
