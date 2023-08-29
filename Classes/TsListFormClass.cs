using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.CSharp.Class
{
    public class TsListFormClass : IClass, IGenerator
    {
        public string Name { get; set; }
        public string ParamName => StringHelper.ToLowerFirstChar(ClassInfo.Name);
        public TsListFormClass(ModelMetadata classInfo)
        {
            ClassInfo = classInfo;
        }

        public ModelMetadata ClassInfo { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"{CreateListFormPropsInterface()}

{CreateComponentText()}
  
{CreateRowComponentText()}
";

        private object CreateListFormPropsInterface()
        {
            return $@"export interface I{ClassInfo.Name}ListFormProps
{{
    items: {ClassInfo.Name}[],
    autoFetch: boolean
}}";
        }

        private object CreateRowComponentText()
        {
            return $@"const {ClassInfo.Name}Row = ({ParamName}: {ClassInfo.Name}) => {{
    return (<tr>
{TsRowPropBuilder.GetPropsText(ClassInfo)}
        <td>
            <button className = ""btn btn-secondary"" >Tap the Button</button>
        </td>
    </tr>);
 }}
";
        }
        private object CreateComponentText()
        {
            return $@"export const {ClassInfo.Name}ListForm = (props: I{ClassInfo.Name}ListFormProps) => {{
    // const {{ state, dispatch }} = React.useContext(ContextApp);
    //const [rotoxHouses, setRotoxHouses] = useState<RotoxHouse[]>(props.items);
    // useEffect(() => {{
    //     if(props.autoFetch) {{
    //         RotoxHouseService.getAll().then((orders) => {{
    //             setRotoxHouses(orders);
    //         }});
    //     }}
    // }}, [])

    const {{items}} = props;

    return (
    < div className = ""table-responsive"" >
         < table className = ""table table-striped table-sm"" >
              < thead >
                  < tr >
{TsHeaderPropBuilder.GetPropsText(ClassInfo)}
                           < th ></ th >
                       </ tr >
                   </ thead >
                   < tbody >
                    {{ (items) && items.map(o => {ClassInfo.Name}Row(o))}}
                </ tbody >
            </ table >
        </ div >
    );
}};
";
        }

        public string UsingText => $@"
import {{ useEffect,useState }} from ""react"";
import {{ {ClassInfo.Name} }} from ""../models/{ClassInfo.Name}"";
import {ClassInfo.Name}Service from ""../services/{ClassInfo.Name}Service"";";

        public string Footer => $@"";

        public string Gen()
        {
            return $"{Header}\n\n{Body}\n\n{Footer}";
        }

    }
}
