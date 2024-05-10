import { SyntheticEvent, useContext, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import AuthService from "../services/AuthService";
import { loginAction, logoutAction } from "../state/auth-state";
import { ContextApp} from "../state/state";

export const AuthControl = () => {
    const { state, dispatch } = useContext(ContextApp);
    let navigate = useNavigate();
    let { user } = state.auth;

    const logout = () => {
        AuthService.logout();
        dispatch(logoutAction);
    }

    const click = () => {
        if(user) {
            logout();
        }         
        navigate("/login");
    }

    const LoginComponent = (
        <div className="flex-shrink-0 dropdown">
            <div className="row" >
                <span>{(user) ? `Здравствуйте, ${user.name}!` : 'Пожалуйста, войдите'}! {(user) && <button type="button" className="btn btn-primary" onClick={click}>Выйти</button>}</span>
            </div>
        </div>
    );

    return (
        <div>
            {LoginComponent}
        </div>
    );
}