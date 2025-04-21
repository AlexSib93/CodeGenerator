using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
{ImportMasterDetailTypes()}";

        private string ImportMasterDetailTypes()
        {
            List<string> detailTypes = new List<string>();
            foreach (ComponentMetadata componentDetailTable in Form.Components.Where(c => c.Type == ComponentTypeEnum.DetailTable.ToString()))
            {
                string detailType = componentDetailTable.ModelPropMetadata.TypeOfEnumerable;
                ModelMetadata detailMetadata = ProjectMetadata.Models.FirstOrDefault(m => m.Name == detailType);
                if(!detailTypes.Contains(detailMetadata.Name))
                {
                    detailTypes.Add(detailMetadata.Name);
                };
            }

            string res = string.Join(Environment.NewLine, detailTypes.Select(t => $@"import {{{t},init{t}}} from '../models/{t}';
import {t}EditForm from './{t}EditForm';"));

            List<string> masterTypes = new List<string>();
            foreach (ComponentMetadata componentDetailTable in Form.Components.Where(c => c.Type == ComponentTypeEnum.LookUp.ToString()))
            {
                ModelMetadata detailMetadata = ProjectMetadata.Models.FirstOrDefault(m => m.Name == componentDetailTable.ModelPropMetadata.Name);
                if (!masterTypes.Contains(detailMetadata.Name))
                {
                    masterTypes.Add(detailMetadata.Name);
                };
            }
            res += Environment.NewLine + string.Join(Environment.NewLine, masterTypes.Except(detailTypes).Select(t => $@"import {{{t},init{t}}} from '../models/{t}';"));
            res += Environment.NewLine + string.Join(Environment.NewLine, masterTypes.Select(t => $@"import {t}Service from ""../services/{t}Service"";"));

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

{MasterValuesInit()}

{DetailsMethods()}

   const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {{
     const {{ name, value }} = e.target;
     setEditedItem({{ ...editedItem, [name]: value }});
   }};

   const handleCheckBoxChange = (e: ChangeEvent<HTMLInputElement>) => {{
    const {{ name, checked }} = e.target;
    setEditedItem({{ ...editedItem, [name]: checked }});
  }};

  const handleSelectChange = (e: ChangeEvent<HTMLSelectElement>) => {{
    const {{ name, value }} = e.target;
    setEditedItem({{ ...editedItem, [name]: parseInt(value) }});
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
            foreach (ComponentMetadata componentLookUp in Form.Components.Where(c => c.Type == ComponentTypeEnum.LookUp.ToString()))
            {
                res += $@"  
  const [lookUpItems{componentLookUp.ModelPropMetadata.Type}, setLookUpItems{componentLookUp.ModelPropMetadata.Type}] = useState<{componentLookUp.ModelPropMetadata.Type}[]>();
  
  useEffect(() => {{
    {componentLookUp.ModelPropMetadata.Type}Service.getall().then((item) => {{
        setLookUpItems{componentLookUp.ModelPropMetadata.Type}(item);
    }});
  }}, [])

  const selectLookUpItems{componentLookUp.ModelPropMetadata.Type} = useMemo(()=>lookUpItems{componentLookUp.ModelPropMetadata.Type} ? lookUpItems{componentLookUp.ModelPropMetadata.Type}.map(i => <option value={{i.id{componentLookUp.ModelPropMetadata.Type}}} selected={{i.id{componentLookUp.ModelPropMetadata.Type}===editedItem.id{componentLookUp.ModelPropMetadata.Name}}}>{{i}}</option>):null, [lookUpItems{componentLookUp.ModelPropMetadata.Type}]);

";
            }

            return res;
        }

        private string MasterEditformShownCondition()
        {
            string res = "";
            foreach (ComponentMetadata componentDetailTable in Form.Components.Where(c => c.Type == ComponentTypeEnum.DetailTable.ToString()))
            {
                res += $@"!edited{componentDetailTable.Name} && ";
            }

            return res;
        }

        private object DetailsEditForms()
        {
            string res = "";
            foreach (ComponentMetadata componentDetailTable in Form.Components.Where(c => c.Type == ComponentTypeEnum.DetailTable.ToString()))
            {
                res += $@"
        {{ edited{componentDetailTable.Name} && <{componentDetailTable.ModelPropMetadata.TypeOfEnumerable}EditForm model={{edited{componentDetailTable.Name}}} onSave={{submitEditForm{componentDetailTable.Name}}} onCancel={{handleCancelEdit{componentDetailTable.Name}}} />}}";
            }

            return res;
        }

        private string DetailsMethods()
        {
            string res = "";
            foreach (ComponentMetadata componentDetailTable in Form.Components.Where(c => c.Type == ComponentTypeEnum.DetailTable.ToString()))
            {
                string detailType = componentDetailTable.ModelPropMetadata.TypeOfEnumerable;
                ModelMetadata detailMetadata = ProjectMetadata.Models.FirstOrDefault(m => m.Name == detailType);
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
                if(component.Type == "DetailTable")
                {
                    strings.Add(TsPropBuilder.GetTsComponent(component, $" onAdd={{add{component.Name}}} onEdit={{setEdited{component.Name}}} onDelete={{handleDelete{component.Name}}} items={{editedItem.{StringHelper.ToLowerFirstChar(component.Name)}}}"));
                } 
                else
                {
                    strings.Add(TsPropBuilder.GetTsComponent(component));
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
