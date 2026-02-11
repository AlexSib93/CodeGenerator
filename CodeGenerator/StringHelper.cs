using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public static class StringHelper
    {
        public static string ToLowerFirstChar(string str)
        {
            return !string.IsNullOrEmpty(str) 
                ? (str.Substring(0, 1).ToLower() + str.Substring(1))
                : "";
        }
        public static string ToUpperFirstChar(string str)
        {
            return !string.IsNullOrEmpty(str)
                ? (str.Substring(0, 1).ToUpper() + str.Substring(1))
                : "";
        }

        public static string TrimComment(string line)
        {
            string res = line;
            //убираем то что после комментария
            int startOfComment = line.IndexOf("//");
            if (startOfComment >= 0)
            {
                res = line.Substring(0, startOfComment);
            }

            return res;
        }
    }
}
