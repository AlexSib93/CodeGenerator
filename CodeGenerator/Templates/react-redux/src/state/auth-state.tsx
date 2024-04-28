import React from "react";
import { User } from "../models/user";
import AuthService from "../services/AuthService";
import { Action, AppState } from "./state";

export interface IAuthActionPayload {
  user?: User
}

export interface IAuthState {
  user?: User
}

export const initialAuthState: IAuthState = {
  user: AuthService.getCurrentUser()
}

export const authReducer = (state: IAuthState = initialAuthState, action: Action): IAuthState => {
  const { type, payload } = action;

  switch (type) {
    case AuthActionKind.Login:      
      return {
        ...state,
        user: payload.user
      }
    case AuthActionKind.Logout:
      return {
        ...state,
        user: null
      }
    default:
      return state;
  }
}

export enum AuthActionKind {
  Login = 'LOGIN',
  Logout = 'LOGOUT',
  SetUsers = 'SET_USERS'
}

export const loginAction = (user: User): Action => {
  return {
    type: AuthActionKind.Login,
    payload: {user}
  }
}

export const logoutAction: Action = {
  type: AuthActionKind.Logout,
  payload: {}
}
