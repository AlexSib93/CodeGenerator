import React, { SyntheticEvent, useContext, useState } from "react";
import { Link, Navigate, NavLink, useNavigate } from "react-router-dom";
import AuthService from "../services/AuthService";
import { loginAction, logoutAction } from "../state/auth-state";
import { ContextApp } from '../state/state';
import { AuthControl } from './AuthControl'
import { MessageBox } from "./Modal";

const Header = () => {
    const [show, setShow] = useState<boolean>(false);
    const [notConfirmedRedirectTo, setNotConfirmedRedirectTo] = useState<string>("");
    const [messageBoxText, setMessageBoxText] = useState<string>("");
    const navigate = useNavigate();

    const handleClose = () => setShow(false);

    const redirectToRemoteStore = () => {
        showDialogForRedirect("/remote-store", "Переключиться в режим работы - 'Удаленный склад' ? ");
    }

    const redirectToGpStore = () => {
        showDialogForRedirect("/", "Переключиться в режим работы - 'Склад ГП' ? ");
    }

    const showDialogForRedirect = (redirectUrl: string, messageText: string) => {
        let showDialog = window.location.hash.toLowerCase() !== '#' + redirectUrl;
        if (showDialog) {
            setMessageBoxText(messageText)
            setNotConfirmedRedirectTo(redirectUrl);
            setShow(true);
        }
    }

    const redirect = (url:string) => {
        navigate(url, { replace: true });        
    }

    const handleConfirm = () => {
        setShow(false);
        redirect(notConfirmedRedirectTo);
    }

    const { state, dispatch } = useContext(ContextApp);
    const linkClasses = (props: { isActive: boolean }): string => "nav-link" + (props.isActive ? " active" : "");

    return (
        <header className="py-2 mb-3">
            <nav className="navbar navbar-expand-lg navbar-light bg-light rounded" aria-label="Eleventh navbar example">
                <div className="container-fluid">
                    <NavLink className="navbar-brand" to="/">WD терминал</NavLink>
                    {state.ui.loading && <div className="text-right">
                        <div className="spinner-border" role="status">
                            <span className="visually-hidden">Loading...</span>
                        </div>
                    </div>}
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarsExample09" aria-controls="navbarsExample09" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarsExample09">
                        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                            <li className="nav-item">
                                <NavLink className={linkClasses} aria-current="page" to="#" onClick={redirectToGpStore}>Склад ГП</NavLink>
                            </li>
                            <li>
                                <NavLink className={linkClasses} aria-current="page" to="#" onClick={redirectToRemoteStore}>Удаленный склад</NavLink>
                            </li>
                            <li>
                                <NavLink className={linkClasses} aria-current="page" to="settings">Настройки</NavLink>
                            </li>
                            {/* <li className="nav-item dropdown">
                                <a className="nav-link dropdown-toggle" href="#" id="dropdown09" data-bs-toggle="dropdown" aria-expanded="false">Dropdown</a>
                                <ul className="dropdown-menu" aria-labelledby="dropdown09">
                                    <li><a className="dropdown-item" href="#">Action</a></li>
                                </ul>
                            </li> */}
                        </ul>
                        <AuthControl />
                    </div>
                </div>
            </nav>
            <MessageBox show={show} text={messageBoxText} title="Смена режима работы" onHide={handleClose} onConfirm={handleConfirm} />
        </header >
    );
};

export default Header;