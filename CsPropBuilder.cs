using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class CsPropBuilder
    {
        public static string GetPropsText(ClassModelMetaInfo classInfo)
        {
            string res = "";
            foreach (ClassPropMetaInfo propInfo in classInfo.PropMetaInfo)
            {
                res += $"{GetPropText(propInfo)}\n";
            }

            return res;

        }

        public static string GetPropText(ClassPropMetaInfo propInfo)
        {
            string res = 
                $"      public {propInfo.Type} {propInfo.Name} {{ get; set; }}";

            return res;
        }

    }
}
