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
    }
}
