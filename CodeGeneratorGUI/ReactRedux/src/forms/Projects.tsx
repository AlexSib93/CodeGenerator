
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
    // const { state, dispatch } = React.useContext(ContextApp);

    const [item, setItem] = useState<ProjectMetadata>(null);
    const [items, setItems] = useState<ProjectMetadata[]>(props.items);
    useEffect(() => {
        if(props.autoFetch) {
            ProjectMetadataService.getall().then((item) => {
                setItems(item);
            });
        }
    }, [])

    const addItem = () => {
        setItem({ ...initProjectMetadata });
    }

    const handleSave = (model: ProjectMetadata) => {
        setItem(null);

        //setUser(updatedUser);
        // Here you can make API calls to update the user data in the backend
    };
       return <div className="table-responsive" >
            { !item && <div>
                
      < Table items={items} editClick={setItem} props={[{Name:'name', Caption: 'Наименование'}, {Name:'description', Caption: 'Описание'}, {Name:'path', Caption: 'Путь'}]} />

            </div>}
          
          
        </ div >
};

  


