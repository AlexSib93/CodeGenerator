import React from "react";
import { Action, AppState } from "./state";
import { ModelMetadata, initModelMetadata } from "../models/ModelMetadata";
import { IModalModelProps } from "../forms/ModalModel";

export interface IEditFormsActionPayload {
    modalModel: IModalModelProps,
}

export interface IEditFormsState {
    modalModelProps: IModalModelProps
}

export const initialEditFormsState: IEditFormsState = {
    modalModelProps: {
        show:false,
        editedItem: initModelMetadata,
        title: ""
    }
}

export const editFormsReducer = (state: IEditFormsState = initialEditFormsState, action: Action): IEditFormsState => {
    const { type, payload } = action;

    switch (type) {
        case EditFormsActionKind.Close:
            return {
                ...state,
            };
        default:
            return state;
    }
}

export enum EditFormsActionKind {
    Submit = 'SUBMIT',
    Close = 'CLOSE',
    Save = 'SAVE',
    Edit = 'EDIT'
}

