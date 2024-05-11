
import { useEffect,useState } from "react";
import { ProjectMetadata } from "../models/ProjectMetadata";
import ProjectMetadataService from "../services/ProjectMetadataService";


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

    const handleSave = (model: ProjectMetadata) => {
        setItem(null);

        //setUser(updatedUser);
        // Here you can make API calls to update the user data in the backend
    };

const ProjectMetadataRow = (projectMetadata: ProjectMetadata) => {
    return (<tr>
               <td>{ projectMetadata.name }</td> 
               <td>{ projectMetadata.description }</td> 
               <td>{ projectMetadata.path }</td> 

        <td>
            <button className = "btn btn-secondary" onClick={() => setItem(projectMetadata)} >Edit</button>
        </td>
    </tr>);
 }


    return (
    < div className = "table-responsive" >
         {!item && < table className = "table table-striped table-sm" >
              < thead >
                  < tr >
               <th>Name</th> 
               <th>Description</th> 
               <th>Path</th> 

                           < th ></ th >
                       </ tr >
                   </ thead >
                   < tbody >
                    { (items) && items.map(o => ProjectMetadataRow(o))}
                </ tbody >
            </ table > }
          
        </ div >
    );
};

  


