using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class TsPropBuilder
    {
        public static string GetPropsText(ModelMetadata classInfo)
        {
            string res = "";
            foreach (PropMetadata propInfo in classInfo.Props)
            {
                res += $"{GetPropText(propInfo)}\n";
            }

            return res;
        }

        public static string GetInitPropsText(ModelMetadata classInfo)
        {
            string res = "";
            foreach (PropMetadata propInfo in classInfo.Props)
            {
                res += $"{GetInitPropText(propInfo)}\n";
            }

            return res;
        }

        public static string GetPropText(PropMetadata propInfo)
        {
            string res =
                $"  {StringHelper.ToLowerFirstChar(propInfo.Name)}:{GetTsType(propInfo.Type)};";

            return res;
        }
        public static string GetInitPropText(PropMetadata propInfo)
        {
            string res =
                $"  {StringHelper.ToLowerFirstChar(propInfo.Name)}:{GetTsInitValue(propInfo.Type)},";

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
                case "bool":
                    res = "boolean";
                    break;
                default:
                    break;
            }

            return res;
        }
        private static object GetTsInitValue(string type)
        {
            string res = type;
            switch (type)
            {
                case "int":
                    res = "0";
                    break;
                case "int?":
                    res = "null";
                    break;
                case "DateTime":
                    res = "new Date()";
                    break;
                case "string":
                    res = "''";
                    break;
                case "bool":
                    res = "false";
                    break;
                default:
                    break;
            }

            return res;
        }
    }
}
