import React, { SyntheticEvent, useContext, useState } from "react";
import { Navigate } from "react-router-dom";
import AuthService from "../services/AuthService";
import { ContextApp } from "../state/state";
import { loginAction } from "../state/auth-state";
import { setLoading, showErrorSnackbar } from "../state/ui-state";

const Login = () => {
    const { state, dispatch } = useContext(ContextApp);
    const [userlogin, setUserlogin] = useState('');
    const [userpassword, setUserpassword] = useState('');
    const [redirect, setRedirect] = useState(false);
    const { user } = state.auth;

    const submit = async (e: SyntheticEvent) => {
        e.preventDefault();
        dispatch(setLoading(true));
        AuthService.login(userlogin, userpassword)
            .then(
                (data: any) => {
                    dispatch(loginAction(data));
                    dispatch(setLoading(false));
                    setRedirect(true);
                },
                (message: string) => {
                    dispatch(showErrorSnackbar(message));
                    dispatch(setLoading(false));
                });
    }

    if (redirect) {
        return <Navigate to='/' />;
    }

    return (
        <form onSubmit={submit} className="bg-light rounded form-signin">
            <h1 className="h3 mb-3 fw-normal">{(user) ? user.name : 'Войти'}</h1>
            <div className="form-group">
                <label htmlFor="floatingInputLogin">Логин - Баркод</label>
                <input type="Login" autoComplete="off" className="form-control" id="floatingInputLogin" placeholder="Login - Barcode" onChange={e => setUserlogin(e.target.value)} />
            </div>
            <div className="form-group">
                <label htmlFor="floatingPassword">Пароль</label>
                <input type="password" autoComplete="off" className="form-control" id="floatingPassword" placeholder="Password" onChange={e => setUserpassword(e.target.value)} />
            </div>
            <button className="w-100 btn btn-primary" type="submit">Войти</button>
        </form>
    );
};

export default Login;