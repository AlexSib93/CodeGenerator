﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class ModelMetadata
    {
        public string Name { get; set; }
        public string NameSpace { get; set; }
        public string Caption { get; set; }
        public string InitData { get; set; }
        public PropMetadata PrimaryKeyProp => Props.FirstOrDefault(p => p.IsPrimaryKey);
        public List<PropMetadata> Props { get; set; } = new List<PropMetadata>();
    }
}
