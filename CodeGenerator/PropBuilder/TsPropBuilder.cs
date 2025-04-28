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
                if (propInfo.IsMasterProp || propInfo.IsDictValueProp)
                {
                    res += $"  id{propInfo.Name}:number;\n";
                    res += $"  {StringHelper.ToLowerFirstChar(propInfo.Name)}?:{GetTsType(propInfo)};\n";
                }
                else
                {
                    res += $"  {StringHelper.ToLowerFirstChar(propInfo.Name)}:{GetTsType(propInfo)};\n";
                }


            }

            return res;
        }

        public static string GetInitPropsText(ModelMetadata classInfo)
        {
            string res = "";
            foreach (PropMetadata propInfo in classInfo.Props)
            {
                if (propInfo.IsMasterProp || propInfo.IsDictValueProp)
                {
                    res += $"  id{propInfo.Name}: 0,\n";
                }
                else
                {
                    res += $"{GetInitPropText(propInfo)}\n";
                }

            }

            return res;
        }

        public static string UsingPropTypeText(ModelMetadata modelMetadata)
        {
            string res = "";

            var referencedTypes = modelMetadata.Props.Where(p => (p.IsEnumerable && p.TypeOfEnumerable != modelMetadata.Name || p.IsVirtual && p.Type != modelMetadata.Name));

            var existedImport = new List<string>();
            foreach (PropMetadata prop in referencedTypes)
            {
                if (prop.IsEnumerable)
                {
                    if (!existedImport.Contains(prop.TypeOfEnumerable))
                    {
                        res += $"import {{ {prop.TypeOfEnumerable}, init{prop.TypeOfEnumerable} }} from \"./{prop.TypeOfEnumerable}\";" + Environment.NewLine;
                        existedImport.Add(prop.TypeOfEnumerable);
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
                $"  {StringHelper.ToLowerFirstChar(propInfo.Name)}: { GetTsInitValue(propInfo)},";

            return res;
        }

        private static object GetTsType(PropMetadata type)
        {
            string res = type.Type;
            if(type.IsEnumerable)
            {
                res = $@"{type.TypeOfEnumerable}[]";
            }
            else
            {
                switch (type.Type)
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

        //todo: переделать всё на component.ModelPropMetadata
        public static string GetTsComponent(ComponentMetadata component, string addstring = "")
        {
            string res = "";
            switch (component.Type)
            {
                case "SubmitButton":
                    res = "         <button className=\"w-50 btn btn-success\" type=\"submit\">Сохранить</button>";
                    break;
                case "SaveButton":
                    res = "         <button className=\"w-50 btn btn-success\" type='button' onClick={() => props.onSave(editedItem)} >Сохранить</button>";
                    break;
                case "CancelButton":
                    res = "         <button className=\"w-50 btn btn-danger\"  type='button' onClick={props.onCancel} >Отмена</button>";
                    break;
                case "Input":
                    res = $@"
      <div className=""m-3"">                
        {(string.IsNullOrEmpty(component.Caption) ? "" : $@"<label className=""form-label"" htmlFor=""floatingInput{component.Name}"">{component.Caption}</label>")}
        <input name=""{StringHelper.ToLowerFirstChar(component.Name)}"" className=""form-control"" id=""floatingInput{component.Name}"" placeholder=""{component.Caption}"" autoComplete=""off"" value={{{(component.ModelProp ? "editedItem." : "")}{StringHelper.ToLowerFirstChar(component.Name)}}} onChange={{ handleInputChange }} />
      </div>";
                    break;                    
                case "NumericUpDown":
                    res = $@"
      <div className=""m-3"">            
        {(string.IsNullOrEmpty(component.Caption) ? "" : $@"<label className=""form-label"" htmlFor=""floatingInput{component.Name}"">{component.Caption}</label>")}
        <input name=""{StringHelper.ToLowerFirstChar(component.Name)}"" type=""number"" className=""form-control"" id=""floatingInput{component.Name}"" placeholder=""{component.Caption}"" autoComplete=""off"" value={{{(component.ModelProp ? "editedItem." : "")}{StringHelper.ToLowerFirstChar(component.Name)}}} onChange={{ handleInputChange }} />
      </div>";
                    break;                     
                case "CheckBox":
                    res = $@"
      <div className=""form-check m-3"">
        {(string.IsNullOrEmpty(component.Caption) ? "" : $@"<label className=""form-check-label"" htmlFor=""flexCheck{component.Name}"">{component.Caption}</label>")}
        <input name=""{StringHelper.ToLowerFirstChar(component.Name)}"" className=""form-check-input"" type=""checkbox"" checked={{{(component.ModelProp ? "editedItem." : "")}{StringHelper.ToLowerFirstChar(component.Name)}}} id=""flexCheck{component.Name}"" onChange={{ handleCheckBoxChange }} />
      </div>";
                    break;                
                case "Table":
                    string props = string.Join(", ",component.Props.Where(p=>!p.IsEnumerable).Select(p => $@"{{Name:'{StringHelper.ToLowerFirstChar(p.Name)}', Caption: '{p.Caption}'}}")); ;
                    res = $@"      <div className=""m-3"">    
        <h1 className=""h4 mt-4 fw-normal"">{component.Caption}</h1>
        <Table {addstring} props={{[{props}]}} />
      </div>";
                    break;
                case "DetailTable":
                    string pr = string.Join(", ", component.Props.Where(p => !p.IsEnumerable).Select(p => $@"{{Name:'{StringHelper.ToLowerFirstChar(p.Name)}', Caption: '{p.Caption}'}}")); ;
                    res = $@"      <div className=""m-3 card"">    
        <div className=""card-body""> 
            <div className=""card-title"">
                <h1 className=""h4 fw-normal"">{component.Caption}</h1>
            </div>
            <div className=""card-text"">
                <Table {addstring} props={{[{pr}]}} />
            </div>
        </div>
      </div>";
                    break;
                case "Grid":
                    string prGrid = string.Join(", ", component.Props.Where(p => !p.IsEnumerable).Select(p => $@"{{Name:'{StringHelper.ToLowerFirstChar(p.Name)}', Caption: '{p.Caption}', Visible: {p.Visible.ToString().ToLower()}, Type: '{p.Type}'}}")); ;
                    res = $@"      <div className=""m-3 card"">    
        <div className=""card-body""> 
            <div className=""card-title"">
                <h1 className=""h4 fw-normal"">{component.Caption}</h1>
            </div>
            <div className=""card-text"">
                <Grid {addstring} props={{[{prGrid}]}} />
            </div>
        </div>
      </div>";
                    break;
                case "AddButton":
                    res = $@"
            <button className=""w-100 btn btn-success"" onClick={{addItem}} >Добавить</button>";
                    break;
                case "DateTime":
                    res = $@"
      <div className=""m-3"">   
            {(string.IsNullOrEmpty(component.Caption) ? "" : $@"<label className=""form-label"" htmlFor=""{component.Name}"">{component.Caption}</label>")}
            <input name=""{StringHelper.ToLowerFirstChar(component.Name)}""  id=""{component.Name}"" className=""form-control"" type=""date"" defaultValue={{ new Date({(component.ModelProp ? "editedItem." : "")}{StringHelper.ToLowerFirstChar(component.Name)}+ 'Z').toISOString().substring(0, 10)}} onChange={{handleInputChange}}  />
      </div>";
                    break;
                case "LookUp":
                    res = $@"
      <div className=""m-3"">   
        <label className=""form-label"" htmlFor=""{StringHelper.ToLowerFirstChar(component.ModelPropMetadata.Name)}"">{component.Caption}</label>
        <select name=""{StringHelper.ToLowerFirstChar(component.ModelPropMetadata.Name)}"" className=""form-control selectpicker"" data-live-search=""true"" id=""{StringHelper.ToLowerFirstChar(component.ModelPropMetadata.Name)}""  value={{editedItem.id{component.ModelPropMetadata.Name}}}  onChange={{(e) =>  handleSelectChange(e, (id:number) => lookUpItems{component.ModelPropMetadata.Type}.find(p => p.id{component.ModelPropMetadata.Type} === id))}}>
            {{selectLookUpItems{component.ModelPropMetadata.Type}}}
        </select>
      </div> 
";
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

        private static object GetTsInitValue(PropMetadata type)
        {
            string res = type.Type;
            if (type.IsEnumerable)
            {
                res = "[]";
            }
            else
            {
                switch (type.Type)
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
                        res = $"init{type.Type}";
                        break;
                }
            }

            return res;
        }
    }
}
