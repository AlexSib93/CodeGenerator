
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
    //const [rotoxHouses, setRotoxHouses] = useState<RotoxHouse[]>(props.items);
    // useEffect(() => {
    //     if(props.autoFetch) {
    //         RotoxHouseService.getAll().then((orders) => {
    //             setRotoxHouses(orders);
    //         });
    //     }
    // }, [])

    const {items} = props;

    return (
    < div className = "table-responsive" >
         < table className = "table table-striped table-sm" >
              < thead >
                  < tr >
               <th>name</th> 
               <th>description</th> 
               <th>path</th> 

                           < th ></ th >
                       </ tr >
                   </ thead >
                   < tbody >
                    { (items) && items.map(o => ProjectMetadataRow(o))}
                </ tbody >
            </ table >
        </ div >
    );
};

  
const ProjectMetadataRow = (projectMetadata: ProjectMetadata) => {
    return (<tr>
               <td>{ projectMetadata.name }</td> 
               <td>{ projectMetadata.description }</td> 
               <td>{ projectMetadata.path }</td> 

        <td>
            <button className = "btn btn-secondary" >Tap the Button</button>
        </td>
    </tr>);
 }



