using CodeGenerator.Metadata;
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

        public static string UsingPropTypeText(IEnumerable<PropMetadata> props)
        {
            string res = "";
            foreach (PropMetadata prop in props)
            {
                if (prop.Type.StartsWith("List"))
                {
                    string classOfArray = prop.Type.Substring(prop.Type.IndexOf("<") + 1, prop.Type.IndexOf(">") - prop.Type.IndexOf("<") - 1);
                    res += $"import {{ {classOfArray} }} from \"./{classOfArray}\";" + Environment.NewLine;

                }
            }            

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
            if(type.StartsWith("List"))
            {
                string classOfArray = type.Substring(type.IndexOf("<")+1, type.IndexOf(">") - type.IndexOf("<") - 1);
                res = $@"{classOfArray}[]";
            }
            else
            {
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
            }

            return res;
        }
        public static object GetTsComponent(ComponentMetadata component, string addstring = "")
        {
            string res = "";
            switch (component.Type)
            {
                case "SubmitButton":
                    res = "         <button className=\"w-100 btn btn-success\" type=\"submit\">Сохранить</button>";
                    break;
                case "Input":
                    res = $@"
      <div className=""form-floating m-3"">                
        <input name=""{StringHelper.ToLowerFirstChar(component.Name)}"" className=""form-control"" id=""floatingInput{component.Name}"" placeholder=""{component.Caption}"" value={{editedItem.{StringHelper.ToLowerFirstChar(component.Name)}}} onChange={{ handleInputChange}} />
        <label htmlFor=""floatingInput{component.Name}"">{component.Caption}</label>
      </div>";
                    break;                
                case "Table":
                    string props = string.Join(", ",component.Props.Where(p=>!p.Type.StartsWith("List")).Select(p => $@"{{Name:'{StringHelper.ToLowerFirstChar(p.Name)}', Caption: '{p.Caption}'}}")); ;
                    res = $@"      <div className=""m-3"">    
       <h1 className=""h4 mt-4 fw-normal"">{component.Caption}</h1>
       <Table {addstring} props={{[{props}]}} />
      </div>";
                    break;
                case "AddButton":
                    res = $@"
            <button className=""w-100 btn btn-success"" onClick={{addItem}} >Добавить</button>";
                    break;
                default:
                    break;
            }

            return res;
        }

        private static object GetTsInitValue(string type)
        {
            string res = type;
            if (type.StartsWith("List"))
            {
                res = "[]";
            }
            else
            {
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
            }

            return res;
        }
    }
}
