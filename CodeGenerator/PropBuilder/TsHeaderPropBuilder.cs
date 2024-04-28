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
                res += $"{GetPropText(classInfo.Name, propInfo)}\n";
            }

            return res;
        }

        public static string GetPropText(string modelName, PropMetadata propInfo)
        {
            return $"               <th>{StringHelper.ToLowerFirstChar(propInfo.Name)}</th> ";
        }
    }
}
