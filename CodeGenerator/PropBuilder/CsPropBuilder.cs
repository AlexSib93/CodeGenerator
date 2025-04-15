using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class CsPropBuilder
    {
        public static string GetPropsText(ModelMetadata classInfo)
        {
            string res = "";
            foreach (PropMetadata propInfo in classInfo.Props)
            {
                if (propInfo.IsPrimaryKey)
                    res += "        [Key]" + Environment.NewLine;

                if (propInfo.IsVirtual)
                {
                    if(propInfo.IsEnumerable)
                    {
                        res += $@"
        {((propInfo.JsonIgnore) ? "[JsonIgnore()]" : "")}
        public virtual {propInfo.Type} {propInfo.Name} {{ get; set; }}";
                    }
                    else
                    {
                        res += $@"
        public int? Id{propInfo.Name} {{ get; set; }}

        {((propInfo.JsonIgnore) ? "[JsonIgnore()]" : "")}
        [ForeignKey(""Id{propInfo.Name}"")]
        public virtual {propInfo.Type} {propInfo.Name} {{ get; set; }}";
                    }
                } 
                else
                {
                    res += $"{GetPropText(propInfo)}\n";
                }

            }

            return res;
        }

        public static string GetPropText(PropMetadata propInfo)
        {
            string res = $"        public {propInfo.Type} {propInfo.Name} {{ get; set; }}";

            return res;
        }

    }
}
