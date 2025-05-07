using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class EnumMetadata
    {
        public int IdEnumMetadata { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public List<EnumValueMetadata> Values { get; set; }
    }
}
