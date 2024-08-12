
import { useEffect,useState } from "react";
import { ProjectMetadata,  initProjectMetadata } from "../models/ProjectMetadata";
import ProjectMetadataService from "../services/ProjectMetadataService";
import { Table } from "../components/Table";


export interface IProjectsProps
{
    items: ProjectMetadata[],
    autoFetch: boolean
}

export const Projects = (props: IProjectsProps) => {
    const [item, setItem] = useState<ProjectMetadata>(null);
    const [items, setItems] = useState<ProjectMetadata[]>(props.items);

    useEffect(() => {
        if (props.autoFetch) {
            ProjectMetadataService.getall().then((item) => {
                setItems(item);
            });
        }
    }, [])


    const addItem = () => {
        var newItem = { ...initProjectMetadata };
        setItem(newItem);
    }

    const handleAdd = (model: ProjectMetadata) => {
        setItems([...items, model]);
    };

    const handleEdit = (model: ProjectMetadata) => {
        var newItems = items.map(i => (i === item) ? model : i);
        setItems(newItems);
        setItem(null);
    };

    const handleDelete = (model: ProjectMetadata) => {
        var newItems = items.filter(i => i !== model);
        setItems(newItems);
    };

    const submitEditForm = (model: ProjectMetadata) => {
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
       <h1 className="h4 mt-4 fw-normal">Проекты</h1>
       <Table items={items} onEdit={setItem} onDelete={handleDelete} onAdd={addItem} props={[{Name:'name', Caption: 'Наименование'}, {Name:'description', Caption: 'Описание'}, {Name:'path', Caption: 'Путь'}]} />
      </div>
        </div>}
            
        </ div >
    };

  


