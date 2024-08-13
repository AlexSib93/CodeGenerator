using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Metadata
{
    public class ComponentMetadata
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool ModelProp { get; set; } = true;
        public List<PropMetadata> Props { get; set; } = new List<PropMetadata>();
    }
}
