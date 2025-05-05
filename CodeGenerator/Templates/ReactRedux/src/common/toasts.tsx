import { useContext, useState } from "react";
import { Toast, ToastContainer } from "react-bootstrap"
import { ContextApp, ContextType } from "../state/state";
import { clearSnackbar } from "../state/ui-state";

export const Toasts = () => {
    const { state, dispatch } = useContext<ContextType>(ContextApp);
    const { message, messageType, snackbarOpen } = state.ui;

    const hide = () => {
        dispatch(clearSnackbar());
    }

    return <ToastContainer position="bottom-center" className="p-3 text-white align-items-center position-fixed" >
        <Toast show={snackbarOpen} bg={messageType} onClose={() => hide()} autohide className="d-flex">
            <Toast.Body>{message}</Toast.Body>
            <button type="button" className="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
        </Toast>
    </ToastContainer>

}