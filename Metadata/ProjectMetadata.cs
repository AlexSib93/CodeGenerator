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
        public List<ClassMetadata> Classes { get; set; }
    }
}
