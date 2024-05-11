
import { useEffect, useState } from "react";
import { ModelMetadata } from "../models/ModelMetadata";
import ModelMetadataService from "../services/ModelMetadataService";
import EditForm from "./Model";

export interface IModelsProps {
    items: ModelMetadata[],
    autoFetch: boolean
}

export const Models = (props: IModelsProps) => {
    // const { state, dispatch } = React.useContext(ContextApp);
    const [items, setItems] = useState<ModelMetadata[]>(props.items);
    const [item, setItem] = useState<ModelMetadata>(null);
    useEffect(() => {
        if (props.autoFetch) {
            ModelMetadataService.getall().then((item) => {
                setItems(item);
                if (items.length > 0) {
                    setItem(items[0]);
                }
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
            <td>{modelMetadata.name}</td>
            <td>{modelMetadata.nameSpace}</td>
            <td>{modelMetadata.caption}</td>
    
            <td>
                <button className="btn btn-secondary"  onClick={() => setItem(modelMetadata)}>Tap the Button</button>
            </td>
        </tr>);
    }
    return (
        < div className="table-responsive" >
            < table className="table table-striped table-sm" >
                < thead >
                    < tr >
                        <th>Имя</th>
                        <th>Пространство имен</th>
                        <th>Отображаемое имя</th>

                        < th ></ th >
                    </ tr >
                </ thead >
                < tbody >
                    {(items) && items.map(o => ModelMetadataRow(o))}
                </ tbody >
            </ table >
            <div>
                {item && <EditForm model={item} onSave={handleSave} />}
            </div>
        </ div >
    );
};





