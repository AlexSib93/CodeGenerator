using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ProjectFiles.Ts
{
    public class TsEnum : IGenerator
    {
        public EnumMetadata EnumMetadata { get; set; }
        public TsEnum(EnumMetadata enumMetadata)
        {
            EnumMetadata = enumMetadata;
        }
        public string Gen()
        {
            return $@"{Header}{Environment.NewLine}{Body}";
        }

        public string Header => $@"";


        public string Body => $@"export enum {EnumMetadata.Name} {{
    Unknown = 0,
{GetEnumItemsText()}
}}

export const init{EnumMetadata.Name} = {EnumMetadata.Name}.Unknown";

        private string GetEnumItemsText()
        {
            string res = string.Join(",\n", EnumMetadata.Values.Select(v => $@"    {v.Name} = {v.Id}"));

            return res;
        }


    }
}
