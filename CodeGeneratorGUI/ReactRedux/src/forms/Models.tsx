
import { useEffect,useState } from "react";
import { ModelMetadata,  initModelMetadata } from "../models/ModelMetadata";
import ModelMetadataService from "../services/ModelMetadataService";
import { Table } from "../components/Table";
import Model from "./Model";

export interface IModelsProps
{
    items: ModelMetadata[],
    autoFetch: boolean
}

export const Models = (props: IModelsProps) => {
    const [item, setItem] = useState<ModelMetadata>(null);
    const [items, setItems] = useState<ModelMetadata[]>(props.items);

    useEffect(() => {
        if (props.autoFetch) {
            ModelMetadataService.getall().then((item) => {
                setItems(item);
            });
        }
    }, [])


    const addItem = () => {
        var newItem = { ...initModelMetadata };
        setItem(newItem);
    }

    const handleAdd = (model: ModelMetadata) => {
        setItems([...items, model]);
    };

    const handleEdit = (model: ModelMetadata) => {
        var newItems = items.map(i => (i === item) ? model : i);
        setItems(newItems);
        setItem(null);
    };

    const handleDelete = (model: ModelMetadata) => {
        var newItems = items.filter(i => i !== model);
        setItems(newItems);
    };

    const submitEditForm = (model: ModelMetadata) => {
        if(items.some(m => m === item)) {
            handleEdit(model);
        } else {
            handleAdd(model);
        }
        setItem(null); 
    }

    return <div className="table-responsive" >
        { !item && <div>
            
      < Table items={items} onEdit={setItem} onDelete={handleDelete} onAdd={addItem} props={[{Name:'name', Caption: 'Имя'}, {Name:'nameSpace', Caption: 'Пространство имен'}, {Name:'caption', Caption: 'Отображаемое имя'}]} />

        </div>}
             {item && <div>
                <Model model={item} onSave={submitEditForm} />
            </div> }
        </ div >
    };

  


