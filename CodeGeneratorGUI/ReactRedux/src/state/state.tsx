import React from "react";
import { authReducer, IAuthActionPayload, IAuthState, initialAuthState } from "./auth-state";
import { IUiActionPayload, IUserInterface, uiReducer, uiInit } from "./ui-state";
import { IModelDialogActionPayload } from "./model-dialog-state";

export const ContextApp = React.createContext<ContextType | null>(null);
export const initialAppState: AppState = { auth: initialAuthState, ui: uiInit }

export const appReducer = (state: AppState = initialAppState, action: Action): AppState => {
    switch (action.type) {
        default:
            let { ui, auth } = state;
            return {
                ...state,
                ui: uiReducer(ui, action),
                auth: authReducer(auth, action)
            };
    }
}

export type Action = IActionWithPayload;
export interface IActionWithPayload {
    type: string;
    payload: IUiActionPayload & IAuthActionPayload & IModelDialogActionPayload;
}

export interface ContextType {
    state: AppState;
    dispatch: React.Dispatch<Action>;
}

export interface AppState { auth: IAuthState, ui: IUserInterface };
