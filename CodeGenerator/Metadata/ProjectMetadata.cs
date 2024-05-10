using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Metadata
{
    public class ProjectMetadata
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public List<ModelMetadata> Models { get; set; } = new List<ModelMetadata>();
        public List<FormMetadata> Forms { get; set; } = new List<FormMetadata>();
    }
}
