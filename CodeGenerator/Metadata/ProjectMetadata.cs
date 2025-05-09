﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Metadata
{
    public class ProjectMetadata
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string DbConnectionString { get; set; }
        // Todo: переделать на enum
        public string UnitOfWork { get; set; } = "MockUnit";
        public int WebApiHttpsPort { get; set; } = 7112;
        public int DevServerPort { get; set; } = 3000;
        public List<ModelMetadata> Models { get; set; } = new List<ModelMetadata>();
        public List<FormMetadata> Forms { get; set; } = new List<FormMetadata>();
        public List<EnumMetadata> EnumTypes { get; set; } = new List<EnumMetadata> { };

        public ModelMetadata GetType(string typeName)
        {
            ModelMetadata res = Models.FirstOrDefault(m => m.Name == typeName);

            return res;
        }

        public EnumMetadata GetEnumType(string typeName)
        {
            EnumMetadata res = EnumTypes.FirstOrDefault(m => m.Name == typeName);

            return res;
        }
    }
}
