using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
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
        public TsEditForm(FormMetadata formMeta)
        {
            Form = formMeta;
        }

        public string Header => $@"{UsingText}";
        public string UsingText => $@"
import React, {{ useState, ChangeEvent, FormEvent, useEffect }} from 'react';
import {{ {Form.Model.Name} }} from ""../models/{Form.Model.Name}"";
import {Form.Model.Name}Service from ""../services/{Form.Model.Name}Service"";
import {{Table}} from ""../components/Table"";";

        public string Body => $@"
 interface {Form.Name}Props {{
   model: {Form.Model.Name};
   onSave: (updatedUser: {Form.Model.Name}) => void;
 }}
 
 const {Form.Name}: React.FC<{Form.Name}Props> = ({{ model: user, onSave }}) => {{
   const [editedItem, setEditedItem] = useState<{Form.Model.Name}>({{ ...user }},);

   const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {{
     const {{ name, value }} = e.target;
     setEditedItem({{ ...editedItem, [name]: value }});
   }};

   const handleCheckBoxChange = (e: ChangeEvent<HTMLInputElement>) => {{
    const {{ name, checked }} = e.target;
    setEditedItem({{ ...editedItem, [name]: checked }});
  }};

   const handleSubmit = (e: FormEvent) => {{
     e.preventDefault();
     onSave(editedItem);
   }};
 
   return (
     <form onSubmit={{handleSubmit}} className=""form"">
       <h1 className=""h3 mb-3 fw-normal"">{Form.Caption}</h1>
           {ComponentsText()}
     </form>
   );
 }};
";

        private string ComponentsText()
        {
            return string.Join(Environment.NewLine, Form.Components.Select(c => TsPropBuilder.GetTsComponent(c, "items={editedItem.props}")));
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
