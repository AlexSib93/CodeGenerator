
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

    const addItem = () => {
        setItem({ ...initModelMetadata });
    }

    const handleSave = (model: ModelMetadata) => {
        setItem(null);

        //setUser(updatedUser);
        // Here you can make API calls to update the user data in the backend
    };
       return <div className="table-responsive" >
          
      < Table items={items} editClick={setItem} props={[{Name:'name', Caption: 'Имя'}, {Name:'nameSpace', Caption: 'Пространство имен'}, {Name:'caption', Caption: 'Отображаемое имя'}]} />


            <button className="w-100 btn btn-lg btn-primary" onClick={addItem} >Добавить</button>
           {item && <div>
                <Model model={item} onSave={handleSave} />
            </div> }
        </ div >
};

  


