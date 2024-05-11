using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
using System;
using System.Collections.Generic;
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

        private object CreateRowComponentText()
        {
            return $@"const {FormInfo.Model.Name}Row = ({StringHelper.ToLowerFirstChar(FormInfo.Model.Name)}: {FormInfo.Model.Name}) => {{
    return (<tr>
{TsRowPropBuilder.GetPropsText(FormInfo.Model)}
        <td>
            <button className = ""btn btn-secondary"" onClick={{() => setItem({StringHelper.ToLowerFirstChar(FormInfo.Model.Name)})}} >Edit</button>
        </td>
    </tr>);
 }}
";
        }
        private object CreateComponentText()
        {
            return $@"export const {FormInfo.Name} = (props: I{FormInfo.Name}Props) => {{
    // const {{ state, dispatch }} = React.useContext(ContextApp);

    const [item, setItem] = useState<{FormInfo.Model.Name}>(null);
    const [items, setItems] = useState<{FormInfo.Model.Name}[]>(props.items);
    useEffect(() => {{
        if(props.autoFetch) {{
            {FormInfo.Model.Name}Service.getall().then((item) => {{
                setItems(item);
            }});
        }}
    }}, [])

    const handleSave = (model: {FormInfo.Model.Name}) => {{
        setItem(null);

        //setUser(updatedUser);
        // Here you can make API calls to update the user data in the backend
    }};

{CreateRowComponentText()}

    return (
    < div className = ""table-responsive"" >
         {{!item && < table className = ""table table-striped table-sm"" >
              < thead >
                  < tr >
{TsHeaderPropBuilder.GetPropsText(FormInfo.Model)}
                           < th ></ th >
                       </ tr >
                   </ thead >
                   < tbody >
                    {{ (items) && items.map(o => {FormInfo.Model.Name}Row(o))}}
                </ tbody >
            </ table > }}
          {EditFormComponent()}
        </ div >
    );
}};
";
        }

        private string EditFormComponent()
        {
            return (EditForm != null ? $@" {{item && <div>
                <{EditForm.Name} model={{item}} onSave={{handleSave}} />
            </div> }}" : "");
        }

        public string UsingText => $@"
import {{ useEffect,useState }} from ""react"";
import {{ {FormInfo.Model.Name} }} from ""../models/{FormInfo.Model.Name}"";
import {FormInfo.Model.Name}Service from ""../services/{FormInfo.Model.Name}Service"";
{(EditForm != null ? $@"import {EditForm.Name} from ""./{EditForm.Name}"";" : "")}";

        public string Footer => $@"";

        public string Gen()
        {
            return $"{Header}\n\n{Body}\n\n{Footer}";
        }

    }
}
