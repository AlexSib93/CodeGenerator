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

            var referencedTypes = props.Where(p => p.Type.StartsWith("List") || p.IsVirtual);


            foreach (PropMetadata prop in referencedTypes)
            {
                var existedImport = new List<string>();
                if (prop.Type.StartsWith("List"))
                {
                    string classOfArray = prop.Type.Substring(prop.Type.IndexOf("<") + 1, prop.Type.IndexOf(">") - prop.Type.IndexOf("<") - 1);
                    if (!existedImport.Contains(classOfArray))
                    {
                        res += $"import {{ {classOfArray}, init{classOfArray} }} from \"./{classOfArray}\";" + Environment.NewLine;
                        existedImport.Add(classOfArray);
                    }
                }
                else if(prop.IsVirtual)
                {
                    if (!existedImport.Contains(prop.Type))
                    {
                        res += $"import {{ {prop.Type}, init{prop.Type} }} from \"./{prop.Type}\";" + Environment.NewLine;
                        existedImport.Add(prop.Type);
                    }
                }
            }            

            return res;
        }
        public static string GetInitPropText(PropMetadata propInfo)
        {
            string res =
                $"  {StringHelper.ToLowerFirstChar(propInfo.Name)}: { GetTsInitValue(propInfo.Type)},";

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
                    case "decimal":
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
        <input name=""{StringHelper.ToLowerFirstChar(component.Name)}"" className=""form-control"" id=""floatingInput{component.Name}"" placeholder=""{component.Caption}"" autoComplete=""off"" value={{{(component.ModelProp ? "editedItem." : "")}{StringHelper.ToLowerFirstChar(component.Name)}}} onChange={{ handleInputChange }} />
        {(string.IsNullOrEmpty(component.Caption) ? "" : $@"<label htmlFor=""floatingInput{component.Name}"">{component.Caption}</label>")}
      </div>";
                    break;                     
                case "CheckBox":
                    res = $@"
      <div className=""form-check m-3"">
        <input name=""{StringHelper.ToLowerFirstChar(component.Name)}"" className=""form-check-input"" type=""checkbox"" checked={{{(component.ModelProp ? "editedItem." : "")}{StringHelper.ToLowerFirstChar(component.Name)}}} id=""flexCheck{component.Name}"" onChange={{ handleCheckBoxChange }} />
        {(string.IsNullOrEmpty(component.Caption) ? "" : $@"<label className=""form-check-label"" htmlFor=""flexCheck{component.Name}"">{component.Caption}</label>")}
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
                case "DateTime":
                    res = $@"
      <div className=""form m-3"">   
            {(string.IsNullOrEmpty(component.Caption) ? "" : $@"<label htmlFor=""{component.Name}"">{component.Caption}</label>")}
            <input id=""{component.Name}"" className=""form-control"" type=""date"" value={{{(component.ModelProp ? "editedItem." : "")}{StringHelper.ToLowerFirstChar(component.Name)}.toISOString().substring(0, 10)}} onChange={{(e) => set{component.Name}(new Date(e.target.value))}}  />
      </div>";
                    break;
                default:
                    break;
            }

            return res;
        }       
        
        public static object GetTsStateProp(ComponentMetadata component)
        {
            string res = "";
            switch (component.Type)
            {
                case "Input":
                    res = $@"
      const [{StringHelper.ToLowerFirstChar(component.Name)}, set{component.Name}] = useState<string>("""");";
                    break;                     
                case "CheckBox":
                    res = $@"
      const [{StringHelper.ToLowerFirstChar(component.Name)}, set{component.Name}] = useState<bool>(false);";
                    break;        
                case "DateTime":
                    res = $@"
      const [{StringHelper.ToLowerFirstChar(component.Name)}, set{component.Name}] = useState<Date>(new Date());";
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
                    case "decimal":
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
                        res = $"init{type}";
                        break;
                }
            }

            return res;
        }
    }
}
