import { useContext, useReducer } from 'react';
//import { ModalModel } from "./ModalModel"
import { ContextApp, ContextType } from '../state/state';

export const ModalEditForms = () => {
    
    const { state, dispatch } = useContext<ContextType>(ContextApp);
    const { modalModelProps} = state.editForms;
    
    return <div>
        {/* <ModalModel  {...modalModelProps}/> */}
    </div>
}