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
    public class TsListFormClass : IGenerator
    {
        public string Name { get; set; }
        public FormMetadata FormInfo { get; set; }
        public FormMetadata EditForm { get; set; }
        public TsListFormClass(FormMetadata formMeta, FormMetadata editForm)
        {
            FormInfo = formMeta;
            EditForm = editForm;
        }

        public string Header => $@"{UsingText}";
        public string Body => $@"{CreateListFormPropsInterface()}

{CreateComponentText()}
  
";

        private object CreateListFormPropsInterface()
        {
            return $@"export interface I{FormInfo.Name}Props
{{
    items: {FormInfo.Model.Name}[],
    autoFetch: boolean
}}";
        }

        private object CreateComponentText()
        {
            return $@"export const {FormInfo.Name} = (props: I{FormInfo.Name}Props) => {{
    const [item, setItem] = useState<{FormInfo.Model.Name}>(null);
    const [items, setItems] = useState<{FormInfo.Model.Name}[]>(props.items);
{StateNotModelProps()}

    useEffect(() => {{
        if (props.autoFetch) {{
            {FormInfo.Model.Name}Service.getall().then((item) => {{
                setItems(item);
            }});
        }}
    }}, [])


    const addItem = () => {{
        var newItem = {{ ...init{FormInfo.Model.Name} }};
        setItem(newItem);
    }}

    const handleAdd = (model: {FormInfo.Model.Name}) => {{
        setItems([...items, model]);
    }};

    const handleEdit = (model: {FormInfo.Model.Name}) => {{
        var newItems = items.map(i => (i === item) ? model : i);
        setItems(newItems);
        setItem(null);
    }};

    const handleDelete = (model: {FormInfo.Model.Name}) => {{
        var newItems = items.filter(i => i !== model);
        setItems(newItems);
        {FormInfo.Model.Name}Service.delete(model.{StringHelper.ToLowerFirstChar(FormInfo.Model.Props.FirstOrDefault(p => p.IsPrimaryKey).Name)});
    }};

    const submitEditForm = (model: {FormInfo.Model.Name}) => {{
        setItem(null);
        if (model && model.idTypeWork > 0) {{
            {FormInfo.Model.Name}Service.put(model).then((item) => {{
                handleEdit(item);
            }});
        }} else {{
            {FormInfo.Model.Name}Service.post(model).then((item) => {{
                handleAdd(item);
            }});
        }}
    }}

    return <div className=""table-responsive"" >
        {$@"{{ !item && <div>
            {GetComponentsText()}
        </div>}}"}
            {EditFormComponent()}
        </ div >
    }};
";
        }

        private string GetComponentsText()
        {
            return (FormInfo.Components!= null)
                ? string.Join(Environment.NewLine, FormInfo.Components.Select(c => TsPropBuilder.GetTsComponent(c, "items={items} onEdit={setItem} onDelete={handleDelete} onAdd={addItem}")))
                : "";
        }
        private string StateNotModelProps()
        {
            return (FormInfo.Components != null)
                ? string.Join(Environment.NewLine, FormInfo.Components.Where(c => !c.ModelProp).Select(c => TsPropBuilder.GetTsStateProp(c)))
                : "";
        }
        private string EditFormComponent()
        {
            return (EditForm != null ? $@" {{item && <div>
                <{EditForm.Name} model={{item}} onSave={{submitEditForm}} />
            </div> }}" : "");
        }

        public string UsingText => $@"
import {{ useEffect,useState }} from ""react"";
import {{ {FormInfo.Model.Name},  init{FormInfo.Model.Name} }} from ""../models/{FormInfo.Model.Name}"";
import {FormInfo.Model.Name}Service from ""../services/{FormInfo.Model.Name}Service"";
import {{ Table }} from ""../components/Table"";
{(EditForm != null ? $@"import {EditForm.Name} from ""./{EditForm.Name}"";" : "")}";

        public string Footer => $@"";

        public string Gen()
        {
            return $"{Header}\n\n{Body}\n\n{Footer}";
        }

    }
}
