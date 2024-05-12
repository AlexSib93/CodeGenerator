
import { useEffect,useState } from "react";
import { ModelMetadata,  initModelMetadata } from "../models/ModelMetadata";
import ModelMetadataService from "../services/ModelMetadataService";
import Model from "./Model";

export interface IModelsProps
{
    items: ModelMetadata[],
    autoFetch: boolean
}

export const Models = (props: IModelsProps) => {
    // const { state, dispatch } = React.useContext(ContextApp);

    const [item, setItem] = useState<ModelMetadata>(null);
    const [items, setItems] = useState<ModelMetadata[]>(props.items);
    useEffect(() => {
        if(props.autoFetch) {
            ModelMetadataService.getall().then((item) => {
                setItems(item);
            });
        }
    }, [])

    const handleSave = (model: ModelMetadata) => {
        setItem(null);

        //setUser(updatedUser);
        // Here you can make API calls to update the user data in the backend
    };

const ModelMetadataRow = (modelMetadata: ModelMetadata) => {
    return (<tr>
               <td>{ modelMetadata.name }</td> 
               <td>{ modelMetadata.nameSpace }</td> 
               <td>{ modelMetadata.caption }</td> 
               <td>{ modelMetadata.props }</td> 

        <td>
            <button className = "btn btn-secondary" onClick={() => setItem(modelMetadata)} >Edit</button>
        </td>
    </tr>);
 }

    const addItem = () => {
        setItem({...initModelMetadata});
    }

    return (
    < div className = "table-responsive" >
         {!item &&  <div>< table className = "table table-striped table-sm" >
              < thead >
                  < tr >
               <th>Имя</th> 
               <th>Пространство имен</th> 
               <th>Отображаемое имя</th> 
               <th>Свойства</th> 

                           < th ></ th >
                       </ tr >
                   </ thead >
                   < tbody >
                    { (items) && items.map(o => ModelMetadataRow(o))}
                </ tbody >
            
            <button className="w-100 btn btn-lg btn-primary" onClick={addItem} >Добавить</button>
            </ table > </div> }
           {item && <div>
                <Model model={item} onSave={handleSave} />
            </div> }
        </ div >
    );
};

  


