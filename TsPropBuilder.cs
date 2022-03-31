using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class TsPropBuilder
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
                $"  {StringHelper.ToLowerFirstChar(propInfo.Name)}:{GetTsType(propInfo.Type)};";

            return res;
        }



        private static object GetTsType(string type)
        {
            string res = type;
            switch (type)
            {
                case "int":
                    res = "number";
                    break;
                case "int?":
                    res = "number | null";
                    break;
                case "DateTime":
                    res = "Date";
                    break;
                default:
                    break;
            }

            return res;
        }
    }
}
