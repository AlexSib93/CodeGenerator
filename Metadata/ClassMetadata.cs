using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class ClassMetadata
    {
        public string ModelName { get; set; }
        public string NameSpace { get; set; }
        public string Caption{ get; set; }
        public List<PropMetadata> Props { get; set; }
        public string Name { get; internal set; }
    }
}
