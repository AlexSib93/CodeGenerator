import React from "react";
import { Action, AppState } from "./state";
import { ModelMetadata, initModelMetadata } from "../models/ModelMetadata";
import { IModalModelProps } from "../forms/ModalModel";

export interface IEditFormsActionPayload {
    editedItem?: ModelMetadata
}

export interface IEditFormsState {
    modalModelProps: IModalModelProps
}

export const initialEditFormsState: IEditFormsState = {
    modalModelProps: {
        show:true,
        editedItem: initModelMetadata,
        title: "Модель"
    }
}

export const editFormsReducer = (state: IEditFormsState = initialEditFormsState, action: Action): IEditFormsState => {
    const { type, payload } = action;

    switch (type) {
        case EditFormsActionKind.Close:
            return {
                ...state,
                modalModelProps: {
                    ...state.modalModelProps,
                    show: false
                }
            };
        default:
            return state;
    }
}

export const closeAction = (): Action => {
    return {
      type: EditFormsActionKind.Close,
      payload: {}
    }
  }

  export const editAction = (editedItem: ModelMetadata): Action => {
    return {
      type: EditFormsActionKind.Edit,
      payload: { editedItem }
    }
  }

export enum EditFormsActionKind {
    Submit = 'SUBMIT',
    Close = 'CLOSE',
    Save = 'SAVE',
    Edit = 'EDIT'
}

