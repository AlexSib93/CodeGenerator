using CodeGenerator.Enum;
using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;

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

    const {{state,dispatch}} = useContext(ContextApp);
    const [item, setItem] = useState<{FormInfo.Model.Name}>(null);
    const [items, setItems] = useState<{FormInfo.Model.Name}[]>(props.items);
{StateNotModelProps()}

    useEffect(() => {{
        if (props.autoFetch) {{
            dispatch(setLoading(true));
            {FormInfo.Model.Name}Service.getall().then((item) => {{
                setItems(item);
            }}).catch((err) => {{
                dispatch(showErrorSnackbar(err));
            }}).finally(() => {{
                dispatch(setLoading(false));
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
            dispatch(setLoading(true));
        if (model && model.{StringHelper.ToLowerFirstChar(FormInfo.Model.PrimaryKeyProp.Name)} > 0) {{
            {FormInfo.Model.Name}Service.put(model)
                .then((item) => {{
                    dispatch(showSuccessSnackbar('Объект успешно сохранен'));
                    handleEdit(item);
                }}).catch((err) => {{
                    dispatch(showErrorSnackbar(err));
                }}).finally(() => {{
                    dispatch(setLoading(false));
                }});
        }} else {{
            {FormInfo.Model.Name}Service
            .post(model).then((item) => {{
                handleAdd(item);
                dispatch(showSuccessSnackbar('Объект успешно создан'));
            }}).catch((err) => {{
                dispatch(showErrorSnackbar(err));
            }}).finally(() => {{
                dispatch(setLoading(false));
            }});
        }}

    }}

    const cancelEdit = () => {{
        setItem(null);
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
                ? string.Join(Environment.NewLine, FormInfo.Components.Select(c => TsPropBuilder.GetTsComponent(c, "items={items} onEdit={setItem} onDelete={handleDelete} onAdd={addItem} "+((c.TypeString == ComponentTypeEnum.Grid.ToString()) ? " enableFilters={true}" : ""))))
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
                <{EditForm.Name} model={{item}} onSave={{submitEditForm}} onCancel={{cancelEdit}} />
            </div> }}" : "");
        }

        public string UsingText => $@"
import {{  useContext, useEffect, useState }} from ""react"";
import {{ {FormInfo.Model.Name},  init{FormInfo.Model.Name} }} from ""../models/{FormInfo.Model.Name}"";
import {FormInfo.Model.Name}Service from ""../services/{FormInfo.Model.Name}Service"";
import {{ Table }} from ""../components/Table"";
import {{Grid}} from '../components/Grid';
import {{ setLoading, showErrorSnackbar, showSuccessSnackbar }} from ""../state/ui-state"";
import {{ ContextApp }} from ""../state/state"";{ImportEnumTypes()}
{(EditForm != null ? $@"import {EditForm.Name} from ""./{EditForm.Name}"";" : "")}";

        private string ImportEnumTypes()
        {
            var enumLookUpTypes = FormInfo.Components
                .Where(c => c.TypeString == ComponentTypeEnum.Grid.ToString())
                .SelectMany(c => c.Props.Where(p => p.PropType == PropTypeEnum.Enum))
                .Select(p => p.Type)
                .Distinct();

            string res = string.Join(Environment.NewLine, enumLookUpTypes.Select(t => $"import {{ {StringHelper.ToLowerFirstChar(t)}Array, {StringHelper.ToLowerFirstChar(t)}ToString }} from \"../enums/{t}\";"));

            if (!string.IsNullOrEmpty(res))
                res = Environment.NewLine + res;

            return res;
        }

        public string Footer => $@"";

        public string Gen()
        {
            return $"{Header}\n\n{Body}\n\n{Footer}";
        }

    }
}
