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
            return $@"{Header}{Body}";
        }

        public string Header => $@"";


        public string Body => $@"export enum {EnumMetadata.Name} {{
    Unknown = 0,
{GetEnumItemsText()}
}}

export const {StringHelper.ToLowerFirstChar(EnumMetadata.Name)}ToString = (value: {EnumMetadata.Name}): string => {{
    let res: string = '';

    switch (value) {{{GetValues()}

        default:
            break;
    }}

    return res;
}}

export const {StringHelper.ToLowerFirstChar(EnumMetadata.Name)}Array: string[] = [{ValuesArray()}];

export const init{EnumMetadata.Name} = {EnumMetadata.Name}.Unknown";

        private string ValuesArray()
        {
            string res = string.Join(", ", EnumMetadata.Values.Select(v => $@"""{v.Caption}""")) ;


            return res;
        }

        private string GetValues()
        {
            string res = "";

            foreach (EnumValueMetadata val in EnumMetadata.Values)
            {
                res += Environment.NewLine + $@"                case {EnumMetadata.Name}.{val.Name}:
                    res = ""{val.Caption}"";
                    break;";

            }

            return res;
        }

        private string GetEnumItemsText()
        {
            string res = string.Join(",\n", EnumMetadata.Values.Select(v => $@"    {v.Name} = {v.IdEnumValueMetadata}"));

            return res;
        }


    }
}
