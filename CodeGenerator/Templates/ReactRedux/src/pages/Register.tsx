import React, { SyntheticEvent, useState } from "react";
import { initialUser, User } from "../models/user";
import AuthService from "../services/AuthService";

const Register = () => {
    const [userlogin, setUserlogin] = useState('');    
    const [email, setEmail] = useState('');    
    const [userpassword, setUserpassword] = useState('');    
    const [name, setName] = useState('');    
    const [lastname, setLastname] = useState('');    
    const [middlename, setMiddlename] = useState('');    
    const [phone, setPhone] = useState('');

    const submit = async (e: SyntheticEvent) => {
        e.preventDefault();
        var user : User = {...initialUser,
            name,
            lastName: lastname,
            middleName: middlename,
            userPassword: userpassword,
            login: userlogin,
            email
        };
        AuthService.register(user);
    }

    return (
        <form onSubmit={submit} className="form-signin">
            <h1 className="h3 mb-3 fw-normal">Пожалуйста, зарегистрируйтесь</h1>
            <div className="form-floating">
                <input type="name" className="form-control" id="floatingInput" placeholder="Александр" 
                    onChange={ e => setName(e.target.value)}
                />
                <label htmlFor="floatingInput">Имя</label>
            </div>            
            <div className="form-floating">
                <input type="middleName" className="form-control" id="floatingInput" placeholder="Владимирович" 
                    onChange={ e => setMiddlename(e.target.value)}
                />
                <label htmlFor="floatingInput">Отчество</label>
            </div>            
            <div className="form-floating">
                <input type="lastname" className="form-control" id="floatingInput" placeholder="Петров" 
                    onChange={ e => setLastname(e.target.value)}
                />
                <label htmlFor="floatingInput">Фамилия</label>
            </div>
            <div className="form-floating">
                <input type="email" className="form-control" id="floatingInput" placeholder="name@example.com" 
                    onChange={ e => setEmail(e.target.value)}
                />
                <label htmlFor="floatingInput">Электронная почта</label>
            </div>
            <div className="form-floating">
                <input type="login" className="form-control" id="floatingInput" placeholder="name@example.com" 
                    onChange={ e => setUserlogin(e.target.value)}
                />
                <label htmlFor="floatingInput">Логин</label>
            </div>
            <div className="form-floating">
                <input type="phone" className="form-control" id="floatingInput" placeholder="+79505642834" 
                    onChange={ e => setPhone(e.target.value)}
                />
                <label htmlFor="floatingInput">Телефон</label>
            </div>
            <div className="form-floating">
                <input type="password" className="form-control" id="floatingPassword" placeholder="Password" 
                    onChange={ e => setUserpassword(e.target.value)}
                />
                <label htmlFor="floatingPassword">Пароль</label>
            </div>
            <button className="w-100 btn btn-lg btn-primary" type="submit">Отправить</button>
        </form>
    );
};

export default Register;