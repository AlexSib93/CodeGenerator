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
        public string DbConnectionString { get; set; }
        // Todo: переделать на enum
        public string UnitOfWork { get; set; } = "MockUnit";
        public List<ModelMetadata> Models { get; set; } = new List<ModelMetadata>();
        public List<FormMetadata> Forms { get; set; } = new List<FormMetadata>();
        public ModelMetadata GetType(string typeName)
        {
            ModelMetadata res = Models.FirstOrDefault(m => m.Name == typeName);

            return res;
        }
    }
}
