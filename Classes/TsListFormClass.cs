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
        public string ParamName => StringHelper.ToLowerFirstChar(ClassInfo.ModelName);
        public TsListFormClass(ClassMetadata classInfo)
        {
            ClassInfo = classInfo;
        }

        public ClassMetadata ClassInfo { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"{CreateListFormPropsInterface()}

{CreateComponentText()}
  
{CreateRowComponentText()}
}}";

        private object CreateListFormPropsInterface()
        {
            return $@"export interface I{ClassInfo.ModelName}ListFormProps
{{
    items: {ClassInfo.ModelName}[],
    autoFetch: boolean
}}";
        }

        private object CreateRowComponentText()
        {
            return $@"const {ClassInfo.ModelName}Row = ({ParamName}: {ClassInfo.ModelName}) => {{
    return (<tr>
{TsRowPropBuilder.GetPropsText(ClassInfo)}
        <td>
            <button className = ""btn btn-secondary"" >{{ {ParamName}.manufactDocName}}</button>
        </td>
    </tr>);
 }}
";
        }
        private object CreateComponentText()
        {
            return $@"export const RotoxHouseListForm = (props: IRotoxHouseListFormProps) => {{
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
                    {{ (items) && items.map(o => {ClassInfo.ModelName}Row(o))}}
                </ tbody >
            </ table >
        </ div >
    );
}};
";
        }

        public string UsingText => $@"
import {{ useEffect,useState }} from ""react"";
import {{ {ClassInfo.ModelName} }} from ""../models/{ClassInfo.ModelName}"";
import {ClassInfo.ModelName}Service from ""../services/{ClassInfo.ModelName}Service"";";

        public string Footer => $@"";

        public string Gen()
        {
            return $"{Header}\n\n{Body}\n\n{Footer}";
        }

    }
}
