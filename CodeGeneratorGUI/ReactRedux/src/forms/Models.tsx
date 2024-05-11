
import { useEffect,useState } from "react";
import { ModelMetadata } from "../models/ModelMetadata";
import ModelMetadataService from "../services/ModelMetadataService";

export interface IModelsProps
{
    items: ModelMetadata[],
    autoFetch: boolean
}

export const Models = (props: IModelsProps) => {
    // const { state, dispatch } = React.useContext(ContextApp);
    const [items, setItems] = useState<ModelMetadata[]>(props.items);
    useEffect(() => {
        if(props.autoFetch) {
            ModelMetadataService.getall().then((item) => {
                setItems(item);
            });
        }
    }, [])

    //const {items} = props;

    return (
    < div className = "table-responsive" >
         < table className = "table table-striped table-sm" >
              < thead >
                  < tr >
               <th>name</th> 
               <th>nameSpace</th> 
               <th>caption</th> 

                           < th ></ th >
                       </ tr >
                   </ thead >
                   < tbody >
                    { (items) && items.map(o => ModelMetadataRow(o))}
                </ tbody >
            </ table >
        </ div >
    );
};

  
const ModelMetadataRow = (modelMetadata: ModelMetadata) => {
    return (<tr>
               <td>{ modelMetadata.name }</td> 
               <td>{ modelMetadata.nameSpace }</td> 
               <td>{ modelMetadata.caption }</td> 

        <td>
            <button className = "btn btn-secondary" >Tap the Button</button>
        </td>
    </tr>);
 }



