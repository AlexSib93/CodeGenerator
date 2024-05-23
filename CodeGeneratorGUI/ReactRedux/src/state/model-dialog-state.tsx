import React from "react";
import { User } from "../models/user";
import AuthService from "../services/AuthService";
import { Action, AppState } from "./state";
import { ModelMetadata } from "../models/ModelMetadata";

export interface IModelDialogActionPayload {
  item?: ModelMetadata,
  onSubmit?: (item: ModelMetadata) => void
}

export interface IModelDialogState {
  item?: ModelMetadata,
  onSubmit?: (item: ModelMetadata) => void
}

export const initialModelDialogState: IModelDialogState = {
  item: null,
  onSubmit: null
}

export const modelDialogReducer = (state: IModelDialogState = initialModelDialogState, action: Action): IModelDialogState => {
  const { type, payload } = action;

  switch (type) {
    case ModelDialogActionKind.EditItem:      
      return {
        ...state,
        item: payload.item,
        onSubmit: payload.onSubmit,
      };
    default:
      return state;
  }
}

export enum ModelDialogActionKind {
  Submit = 'SUBMIT',
  Close = 'CLOSE',
  EditItem = 'EDIT_ITEM'
}

export const editItemAction = (item: ModelMetadata, onSubmit: (item: ModelMetadata) => void): Action => {
  return {
    type: ModelDialogActionKind.Submit,
    payload: {item , onSubmit}
  }
}
