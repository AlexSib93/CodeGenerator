import React from "react";
import { authReducer, IAuthActionPayload, IAuthState, initialAuthState } from "./auth-state";
import { IUiActionPayload, IUserInterface, uiReducer, uiInit } from "./ui-state";
import { IModalModelProps } from "../forms/ModalModel";
import { editFormsReducer, initialEditFormsState } from "./editforms-state";

export const ContextApp = React.createContext<ContextType | null>(null);
export const initialAppState: AppState = { auth: initialAuthState, ui: uiInit, editForms: initialEditFormsState }

export const appReducer = (state: AppState = initialAppState, action: Action): AppState => {
    switch (action.type) {
        default:
            let { ui, auth, editForms } = state;
            return {
                ...state,
                ui: uiReducer(ui, action),
                auth: authReducer(auth, action),
                editForms: editFormsReducer(editForms, action)
            };
    }
}

export type Action = IActionWithPayload;
export interface IActionWithPayload {
    type: string;
    payload: IUiActionPayload & IAuthActionPayload;
}

export interface ContextType {
    state: AppState;
    dispatch: React.Dispatch<Action>;
}

export interface AppState {
    editForms: { modalModelProps: IModalModelProps }, auth: IAuthState, ui: IUserInterface
};
