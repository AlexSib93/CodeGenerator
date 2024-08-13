
import { useEffect,useState } from "react";
import { FormMetadata,  initFormMetadata } from "../models/FormMetadata";
import FormMetadataService from "../services/FormMetadataService";
import { Table } from "../components/Table";
import Form from "./Form";

export interface IFormsProps
{
    items: FormMetadata[],
    autoFetch: boolean
}

export const Forms = (props: IFormsProps) => {
    const [item, setItem] = useState<FormMetadata>(null);
    const [items, setItems] = useState<FormMetadata[]>(props.items);


    useEffect(() => {
        if (props.autoFetch) {
            FormMetadataService.getall().then((item) => {
                setItems(item);
            });
        }
    }, [])


    const addItem = () => {
        var newItem = { ...initFormMetadata };
        setItem(newItem);
    }

    const handleAdd = (model: FormMetadata) => {
        setItems([...items, model]);
    };

    const handleEdit = (model: FormMetadata) => {
        var newItems = items.map(i => (i === item) ? model : i);
        setItems(newItems);
        setItem(null);
    };

    const handleDelete = (model: FormMetadata) => {
        var newItems = items.filter(i => i !== model);
        setItems(newItems);
    };

    const submitEditForm = (model: FormMetadata) => {
        if(items.some(m => m === item)) {
            handleEdit(model);
        } else {
            handleAdd(model);
        }
        setItem(null); 
    }

    return <div className="table-responsive" >
        { !item && <div>
                  <div className="m-3">    
        <h1 className="h4 mt-4 fw-normal">Формы</h1>
        <Table items={items} onEdit={setItem} onDelete={handleDelete} onAdd={addItem} props={[{Name:'name', Caption: 'Наименование'}, {Name:'caption', Caption: 'Отображаемое имя'}, {Name:'description', Caption: 'Описание'}, {Name:'addToNavBar', Caption: 'Добавить в панель навигации'}]} />
      </div>
        </div>}
             {item && <div>
                <Form model={item} onSave={submitEditForm} />
            </div> }
        </ div >
    };

  


