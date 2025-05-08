using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ProjectFiles.Cs
{
    public class EnumCs : IGenerator
    {
        public EnumMetadata EnumMetadata { get; set; }
        public EnumCs(EnumMetadata enumMetadata)
        {
            EnumMetadata = enumMetadata;
        }
        public string Gen()
        {
            return $@"{Header}{Environment.NewLine}{Body}";
        }

        public string Header => $@"";


        public string Body => $@"namespace DataAccessLayer
{{
    /// <summary>
    /// {EnumMetadata.Caption}
    /// </summary>    
    public enum {EnumMetadata.Name}
    {{
{GetEnumItemsText()}
    }}
}}
";

        private string GetEnumItemsText()
        {
            string res = string.Join(",\n", EnumMetadata.Values.Select(v => $@"        /// <summary>
        /// {v.Caption}
        /// </summary>
        {v.Name} = {v.IdEnumValueMetadata}"));

            return res;
        }


    }
}
