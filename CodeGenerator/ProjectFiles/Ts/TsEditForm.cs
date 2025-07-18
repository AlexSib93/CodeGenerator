﻿using CodeGenerator.Enum;
using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;

namespace CodeGenerator.ProjectFiles.Ts
{
    public class TsEditForm : IGenerator
    {
        public string Name { get; set; }
        public FormMetadata Form { get; set; }
        public ProjectMetadata ProjectMetadata { get; set; }
        public TsEditForm(FormMetadata formMeta, ProjectMetadata projectMetadata)
        {
            Form = formMeta;
            ProjectMetadata = projectMetadata;
        }

        public string Header => $@"{UsingText}";
        public string UsingText => $@"
import React, {{ useState, ChangeEvent, FormEvent, useEffect, useMemo }} from 'react';
import {{ {Form.Model.Name} }} from ""../models/{Form.Model.Name}"";
import {Form.Model.Name}Service from ""../services/{Form.Model.Name}Service"";
import {{Table}} from ""../components/Table"";
import {{Grid}} from '../components/Grid';
{ImportMasterDetailTypes()}";

        private string ImportMasterDetailTypes()
        {
            List<string> detailTypes = new List<string>();
            foreach (ComponentMetadata componentDetailTable in Form.Components.Where(c => (c.Type == ComponentTypeEnum.DetailTable || c.Type == ComponentTypeEnum.Grid) && c.ModelPropMetadata.Type != Form.Model.Name ))
            {
                string detailType = componentDetailTable.ModelPropMetadata.TypeOfEnumerable;
                ModelMetadata detailMetadata = ProjectMetadata.GetType(detailType);
                if(!detailTypes.Contains(detailMetadata.Name))
                {
                    detailTypes.Add(detailMetadata.Name);
                };


            }

            string res = string.Join(Environment.NewLine, detailTypes.Select(t => $@"import {{{t},init{t}}} from '../models/{t}';
import {t}EditForm from './{t}EditForm';"));

            List<string> masterTypes = new List<string>();
            foreach (ComponentMetadata componentDetailTable in Form.Components.Where(c => c.Type == ComponentTypeEnum.LookUp && c.ModelPropMetadata.TypeOfNullable != Form.Model.Name))
            {
                ModelMetadata detailMetadata = ProjectMetadata.GetType(componentDetailTable.ModelPropMetadata.TypeOfNullable);
                if (!masterTypes.Contains(detailMetadata.Name))
                {
                    masterTypes.Add(detailMetadata.Name);
                };
            }


            List<string> enumTypes = new List<string>();
            foreach (ComponentMetadata enumLookUp in Form.Components.Where(c => c.Type == ComponentTypeEnum.EnumLookUp))
            {
                EnumMetadata enumMetadata = ProjectMetadata.GetEnumType(enumLookUp.ModelPropMetadata.Type);
                if (!enumTypes.Contains(enumMetadata.Name))
                {
                    enumTypes.Add(enumMetadata.Name);
                };
            }
            foreach (ComponentMetadata enumLookUp in Form.Components.Where(c => c.Type == ComponentTypeEnum.Grid))
            {
                foreach (PropMetadata prop in enumLookUp.Props.Where(p => p.PropType == PropTypeEnum.Enum))
                {
                    EnumMetadata enumMetadata = ProjectMetadata.GetEnumType(prop.Type);
                    if (!enumTypes.Contains(enumMetadata.Name))
                    {
                        enumTypes.Add(enumMetadata.Name);
                    };
                }

            }

            res += Environment.NewLine + string.Join(Environment.NewLine, masterTypes.Except(detailTypes).Select(t => $@"import {{{t},init{t}}} from '../models/{t}';"));
            res += Environment.NewLine + string.Join(Environment.NewLine, masterTypes.Select(t => $@"import {t}Service from ""../services/{t}Service"";"));
            res += Environment.NewLine + string.Join(Environment.NewLine, enumTypes.Select(t => $@"import {{ {t}, {StringHelper.ToLowerFirstChar(t)}ToString, {StringHelper.ToLowerFirstChar(t)}Array }} from ""../enums/{t}"";"));

            return res;
        }

        public string Body => $@"
 interface {Form.Name}Props {{
   model: {Form.Model.Name};
   onSave: (item: {Form.Model.Name}) => void;
   onCancel: () => void;
 }}
 
 const {Form.Name}: React.FC<{Form.Name}Props> = (props: {Form.Name}Props) => {{
   const [editedItem, setEditedItem] = useState<{Form.Model.Name}>(props.model);

  
  useEffect(() => {{
    if(editedItem.id{Form.Model.Name} > 0) {{
      console.log('useEffect editedItem',editedItem);      
      {Form.Model.Name}Service.get(editedItem.id{Form.Model.Name} ).then((item) => {{
        setEditedItem(item);
      }});
    }}
  }}, [editedItem.id{Form.Model.Name}])

{MasterValuesInit()}

{DetailsMethods()}

   const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {{
     const {{ name, value }} = e.target;

    let newVal: any = value;
    if(e.target.type === 'number') {{
        newVal = +value;
    }}

    if(e.target.type === 'date') {{
        newVal = new Date(value);
    }}

     setEditedItem({{ ...editedItem, [name]: newVal }});
   }};

   const handleCheckBoxChange = (e: ChangeEvent<HTMLInputElement>) => {{
    const {{ name, checked }} = e.target;
    setEditedItem({{ ...editedItem, [name]: checked }});
  }};

const toUpperFirstChar = str => {{
    return str.charAt(0).toUpperCase() + str.slice(1);
  }};

  const handleSelectChange = (e: ChangeEvent<HTMLSelectElement>, getItemFunc: (id: number) => any ) => {{
    const {{ name, value }} = e.target;
    setEditedItem({{ ...editedItem, [""id"" + toUpperFirstChar(name)]: Number(value), [name]: getItemFunc(Number(value)) }});
  }};


  const handleEnumSelectChange = (e: ChangeEvent<HTMLSelectElement>) => {{
    const {{ name, value }} = e.target;
    setEditedItem({{ ...editedItem, [name]: Number(value) }});
  }};

   const handleSubmit = (e: FormEvent) => {{
     e.preventDefault();
     props.onSave(editedItem);
   }};
 
   return (
    <div>
         {{{MasterEditformShownCondition()}<form onSubmit={{handleSubmit}} className=""form"">
           <h1 className=""h3 mb-3 fw-normal"">{Form.Caption}</h1>
               {ComponentsText()}
         </form>}}
{DetailsEditForms()}
    </div>
   );
 }};
";

        private object MasterValuesInit()
        {
            string res = "";
            foreach (ComponentMetadata componentLookUp in Form.Components.Where(c => c.Type == ComponentTypeEnum.LookUp))
            {
                res += $@"  
  const [lookUpItems{componentLookUp.ModelPropMetadata.TypeOfNullable}, setLookUpItems{componentLookUp.ModelPropMetadata.TypeOfNullable}] = useState<{componentLookUp.ModelPropMetadata.TypeOfNullable}[]>();
  
  useEffect(() => {{
    {componentLookUp.ModelPropMetadata.TypeOfNullable}Service.getall().then((item) => {{
        setLookUpItems{componentLookUp.ModelPropMetadata.TypeOfNullable}(item);
    }});
  }}, [])

  const selectLookUpItems{componentLookUp.ModelPropMetadata.TypeOfNullable} = useMemo(()=>lookUpItems{componentLookUp.ModelPropMetadata.TypeOfNullable} ? lookUpItems{componentLookUp.ModelPropMetadata.TypeOfNullable}.map(i => <option  key={{i.id{componentLookUp.ModelPropMetadata.TypeOfNullable}}}  value={{i.id{componentLookUp.ModelPropMetadata.TypeOfNullable}}}>{{{componentLookUp.Props.FirstOrDefault()?.Name ?? ""}}}</option>):null, [lookUpItems{componentLookUp.ModelPropMetadata.TypeOfNullable}]);

";
            }

            return res;
        }

        private string MasterEditformShownCondition()
        {
            string res = "";
            foreach (ComponentMetadata componentDetailTable in Form.Components.Where(c => c.Type == ComponentTypeEnum.DetailTable || c.Type == ComponentTypeEnum.Grid))
            {
                res += $@"!edited{componentDetailTable.Name} && ";
            }

            return res;
        }

        private object DetailsEditForms()
        {
            string res = "";
            foreach (ComponentMetadata componentDetailTable in Form.Components.Where(c => c.Type == ComponentTypeEnum.DetailTable || c.Type == ComponentTypeEnum.Grid))
            {
                res += $@"
        {{ edited{componentDetailTable.Name} && <{componentDetailTable.ModelPropMetadata.TypeOfEnumerable}EditForm model={{edited{componentDetailTable.Name}}} onSave={{submitEditForm{componentDetailTable.Name}}} onCancel={{handleCancelEdit{componentDetailTable.Name}}} />}}";
            }

            return res;
        }

        private string DetailsMethods()
        {
            string res = "";
            foreach (ComponentMetadata componentDetailTable in Form.Components.Where(c => c.Type == ComponentTypeEnum.DetailTable || c.Type == ComponentTypeEnum.Grid))
            {
                string detailType = componentDetailTable.ModelPropMetadata.TypeOfEnumerable;
                ModelMetadata detailMetadata = ProjectMetadata.GetType(detailType);
                ModelMetadata masterMetadata = Form.Model;

            res += $@"
  const [edited{componentDetailTable.Name}, setEdited{componentDetailTable.Name}] = useState<{detailMetadata.Name}>(null);

  const add{componentDetailTable.Name} = () => {{
    let newItem: {detailMetadata.Name} = {{ ...init{detailMetadata.Name}, id{Form.Model.Name}: editedItem.id{Form.Model.Name} }};
    setEdited{componentDetailTable.Name}(newItem);
  }}

  const submitEditForm{componentDetailTable.Name} = (model: {detailMetadata.Name}) => {{
    setEdited{componentDetailTable.Name}(null);
    if (model && model.{StringHelper.ToLowerFirstChar(detailMetadata.PrimaryKeyProp.Name)} > 0) {{
              setEditedItem({{ ...editedItem, {StringHelper.ToLowerFirstChar(componentDetailTable.Name)}: editedItem.{StringHelper.ToLowerFirstChar(componentDetailTable.Name)}.map(i=> (i.{StringHelper.ToLowerFirstChar(detailMetadata.PrimaryKeyProp.Name)}===model.{StringHelper.ToLowerFirstChar(detailMetadata.PrimaryKeyProp.Name)})? model:i)}});
            }} else {{
              setEditedItem({{ ...editedItem, {StringHelper.ToLowerFirstChar(componentDetailTable.Name)}: [...editedItem.{StringHelper.ToLowerFirstChar(componentDetailTable.Name)}, model] }});
            }}
  }}
  
  const handleDelete{componentDetailTable.Name} = (model: {detailMetadata.Name}) => {{
    setEditedItem((current) => {{ 
        var newItems = editedItem.{StringHelper.ToLowerFirstChar(componentDetailTable.Name)}.filter(i => i !== model);
        return {{ ...current, {StringHelper.ToLowerFirstChar(componentDetailTable.Name)}: newItems }} 
    }});
  }};

    const handleCancelEdit{componentDetailTable.Name} = () => {{
        setEdited{componentDetailTable.Name}(null);
    }};
";

            }

            return res;
        }

        private string ComponentsText()
        {
            List<string> strings = new List<string>();
            foreach (ComponentMetadata component in Form.Components)
            {
                if(component.Type == ComponentTypeEnum.DetailTable || component.Type == ComponentTypeEnum.Grid)
                {
                    strings.Add(TsPropBuilder.GetTsComponent(component, $" onAdd={{add{component.Name}}} onEdit={{setEdited{component.Name}}} onDelete={{handleDelete{component.Name}}} items={{editedItem.{StringHelper.ToLowerFirstChar(component.Name)}}}"));
                } 
                else
                {
                    strings.Add(TsPropBuilder.GetTsComponent(component, "", ProjectMetadata));
                }
                
            }
            return string.Join(Environment.NewLine, strings );
        }

        public string Footer => $@"
 export default {Form.Name};
  ";

        public string Gen()
        {
            return $"{Header}\n\n{Body}\n\n{Footer}";
        }

    }
}
