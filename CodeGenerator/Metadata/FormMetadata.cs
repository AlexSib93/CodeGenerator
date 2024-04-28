using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Metadata
{
    internal class FormMetadata
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ModelMetadata Model { get; set; }
        public IEnumerable<ComponentMetadata> Components { get; set; }
    }
}
