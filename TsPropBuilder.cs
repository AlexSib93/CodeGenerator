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
            foreach (ClassPropMetaInfo propInfo in classInfo.PropsMetaInfo)
            {
                res += $"{GetPropText(propInfo)}\n";
            }

            return res;
        }

        public static string GetInitPropsText(ClassModelMetaInfo classInfo)
        {
            string res = "";
            foreach (ClassPropMetaInfo propInfo in classInfo.PropsMetaInfo)
            {
                res += $"{GetInitPropText(propInfo)}\n";
            }

            return res;
        }

        public static string GetPropText(ClassPropMetaInfo propInfo)
        {
            string res =
                $"  {StringHelper.ToLowerFirstChar(propInfo.Name)}:{GetTsType(propInfo.Type)};";

            return res;
        }
        public static string GetInitPropText(ClassPropMetaInfo propInfo)
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
                default:
                    break;
            }

            return res;
        }
    }
}
