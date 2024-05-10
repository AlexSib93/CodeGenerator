
import { useEffect,useState } from "react";
import { TestModel1 } from "../models/TestModel1";
import TestModel1Service from "../services/TestModel1Service";

export interface ITestModelListProps
{
    items: TestModel1[],
    autoFetch: boolean
}

export const TestModelList = (props: ITestModelListProps) => {
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
               <th>id</th> 

                           < th ></ th >
                       </ tr >
                   </ thead >
                   < tbody >
                    { (items) && items.map(o => TestModel1Row(o))}
                </ tbody >
            </ table >
        </ div >
    );
};

  
const TestModel1Row = (testModel1: TestModel1) => {
    return (<tr>
               <td>{ testModel1.name }</td> 
               <td>{ testModel1.description }</td> 
               <td>{ testModel1.id }</td> 

        <td>
            <button className = "btn btn-secondary" >Tap the Button</button>
        </td>
    </tr>);
 }



