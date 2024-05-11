
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

    const [item, setItem] = useState<FormMetadata>(null);
    const [items, setItems] = useState<FormMetadata[]>(props.items);
    useEffect(() => {
        if(props.autoFetch) {
            FormMetadataService.getall().then((item) => {
                setItems(item);
            });
        }
    }, [])

    const handleSave = (model: FormMetadata) => {
        setItem(null);

        //setUser(updatedUser);
        // Here you can make API calls to update the user data in the backend
    };

const FormMetadataRow = (formMetadata: FormMetadata) => {
    return (<tr>
               <td>{ formMetadata.name }</td> 
               <td>{ formMetadata.caption }</td> 
               <td>{ formMetadata.description }</td> 
               <td>{ formMetadata.addToNavBar }</td> 

        <td>
            <button className = "btn btn-secondary" onClick={() => setItem(formMetadata)} >Edit</button>
        </td>
    </tr>);
 }


    return (
    < div className = "table-responsive" >
         {!item && < table className = "table table-striped table-sm" >
              < thead >
                  < tr >
               <th>Name</th> 
               <th>Caption</th> 
               <th>Description</th> 
               <th>AddToNavBar</th> 

                           < th ></ th >
                       </ tr >
                   </ thead >
                   < tbody >
                    { (items) && items.map(o => FormMetadataRow(o))}
                </ tbody >
            </ table > }
          
        </ div >
    );
};

  


