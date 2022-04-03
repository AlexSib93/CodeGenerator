using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class CsPropBuilder
    {
        public static string GetPropsText(ClassMetadata classInfo)
        {
            string res = "";
            foreach (PropMetadata propInfo in classInfo.Props)
            {
                res += $"{GetPropText(propInfo)}\n";
            }

            return res;
        }

        public static string GetPropText(PropMetadata propInfo)
        {
            string res = 
                $"      public {propInfo.Type} {propInfo.Name} {{ get; set; }}";

            return res;
        }

    }
}
