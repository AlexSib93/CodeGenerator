
import { useEffect,useState } from "react";
import { FormMetadata } from "../models/FormMetadata";
import FormMetadataService from "../services/FormMetadataService";

export interface IFormsProps
{
    items: FormMetadata[],
    autoFetch: boolean
}

export const Forms = (props: IFormsProps) => {
    // const { state, dispatch } = React.useContext(ContextApp);
    const [items, setItems] = useState<FormMetadata[]>(props.items);
    useEffect(() => {
        if(props.autoFetch) {
            FormMetadataService.getall().then((item) => {
                setItems(item);
            });
        }
    }, [])


    return (
    < div className = "table-responsive" >
         < table className = "table table-striped table-sm" >
              < thead >
                  < tr >
               <th>name</th> 
               <th>caption</th> 
               <th>description</th> 
               <th>addToNavBar</th> 

                           < th ></ th >
                       </ tr >
                   </ thead >
                   < tbody >
                    { (items) && items.map(o => FormMetadataRow(o))}
                </ tbody >
            </ table >
        </ div >
    );
};

  
const FormMetadataRow = (formMetadata: FormMetadata) => {
    return (<tr>
               <td>{ formMetadata.name }</td> 
               <td>{ formMetadata.caption }</td> 
               <td>{ formMetadata.description }</td> 
               <td>{ formMetadata.addToNavBar }</td> 

        <td>
            <button className = "btn btn-secondary" >Tap the Button</button>
        </td>
    </tr>);
 }



