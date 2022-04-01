using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class ClassModelMetaInfo
    {
        public string ModelName { get; set; }
        public string NameSpace { get; set; }
        public string Caption{ get; set; }
        public List<ClassPropMetaInfo> PropsMetaInfo { get; set; }
    }
}
