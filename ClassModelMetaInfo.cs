using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class ClassModelMetaInfo
    {
        public string ClassModelName { get; set; }
        public string NameSpace { get; set; }
        public List<ClassPropMetaInfo> PropMetaInfo { get; set; }
    }
}
