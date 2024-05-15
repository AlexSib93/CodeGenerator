
import { useEffect,useState } from "react";
import { FormMetadata,  initFormMetadata } from "../models/FormMetadata";
import FormMetadataService from "../services/FormMetadataService";
import { Table } from "../components/Table";


export interface IFormsProps
{
    items: FormMetadata[],
    autoFetch: boolean
}

export const Forms = (props: IFormsProps) => {
    // const { state, dispatch } = React.useContext(ContextApp);

    const [item, setItem] = useState<FormMetadata>(null);
    const [items, setItems] = useState<FormMetadata[]>(props.items);
    useEffect(() => {
        if(props.autoFetch) {
            FormMetadataService.getall().then((item) => {
                setItems(item);
            });
        }
    }, [])

    const addItem = () => {
        setItem({ ...initFormMetadata });
    }

    const handleSave = (model: FormMetadata) => {
        setItem(null);

        //setUser(updatedUser);
        // Here you can make API calls to update the user data in the backend
    };
       return <div className="table-responsive" >
            { !item && <div>
                
      < Table items={items} editClick={setItem} props={[{Name:'name', Caption: 'Наименование'}, {Name:'caption', Caption: 'Отображаемое имя'}, {Name:'description', Caption: 'Описание'}, {Name:'addToNavBar', Caption: 'Добавить в панель навигации'}]} />

            </div>}
          
          
        </ div >
};

  


