using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class TsHeaderPropBuilder
    {
        public static string GetPropsText(ModelMetadata classInfo)
        {
            string res = "";
            foreach (PropMetadata propInfo in classInfo.Props)
            {
                if (!propInfo.Type.StartsWith("List"))
                {
                    res += $"{GetPropText(classInfo.Name, propInfo)}\n";
                }
            }

            return res;
        }

        public static string GetPropText(string modelName, PropMetadata propInfo)
        {
            return (!propInfo.Type.StartsWith("List")) 
                ? $"                <th>{(string.IsNullOrEmpty(propInfo.Caption) ? propInfo.Name : propInfo.Caption)}</th> "
                : "";
        }
    }
}
