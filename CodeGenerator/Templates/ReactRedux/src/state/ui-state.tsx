import { Action } from "./state";

export interface IUserInterface {
    loading: boolean,
    backDropOpen: boolean,
    snackbarOpen: boolean,
    message: string,
    messageType: "success" | "primary" | "warning" | "danger" | undefined
}

export interface IUiActionPayload {
    message?: string;
    messageType?: "success" | "primary" | "warning" | "danger" | undefined;
}

export const uiInit: IUserInterface = {
    loading: false,
    backDropOpen: false,
    messageType: undefined,
    snackbarOpen: false,
    message: ''
}

export enum ActionKind {
    SNACKBAR_MESSAGE = 'SNACKBAR_MESSAGE',
    SNACKBAR_CLEAR = 'SNACKBAR_CLEAR',
    OPEN_BACKDROP = 'OPEN_BACKDROP',
    CLOSE_BACKDROP = 'CLOSE_BACKDROP',
    START_LOADING = 'START_LOADING',
    END_LOADING = 'END_LOADING'
}

export const uiReducer = (state: IUserInterface = uiInit, action: Action): IUserInterface => {
    switch (action.type) {
        case ActionKind.SNACKBAR_MESSAGE:
            return {
                ...state,
                snackbarOpen: true,
                message: action.payload!.message ?? '',
                messageType: action.payload!.messageType
            };
        case ActionKind.SNACKBAR_CLEAR:
            return {
                ...state,
                snackbarOpen: false,
                message: '',
                messageType: undefined
            };
        case ActionKind.OPEN_BACKDROP:
            return {
                ...state,
                backDropOpen: true
            }
        case ActionKind.CLOSE_BACKDROP:
            return {
                ...state,
                backDropOpen: false
            }
        case ActionKind.START_LOADING:
            return {
                ...state,
                loading: true
            }
        case ActionKind.END_LOADING:
            return {
                ...state,
                loading: false
            }
        default:
            return state;
    }
};

export function setLoading(loading: boolean): Action {
    return {
        type: (loading) ? ActionKind.START_LOADING : ActionKind.END_LOADING,
        payload: { }
    };
};

export function showSuccessSnackbar(message: string): Action {
    return {
        type: ActionKind.SNACKBAR_MESSAGE,
        payload: {
            message: message,
            messageType: 'success'
        }
    };
};

export function showErrorSnackbar(message: string): Action {
    return {
        type: ActionKind.SNACKBAR_MESSAGE,
        payload: {
            message: message,
            messageType: 'danger'
        }
    };
};

export function showInfoSnackbar(message: string): Action {
    return {
        type: ActionKind.SNACKBAR_MESSAGE,
        payload: {
            message: message,
            messageType: 'primary'
        }
    };
};

export function clearSnackbar(): Action {
    return {
        type: ActionKind.SNACKBAR_CLEAR,
        payload: {}
    };
};