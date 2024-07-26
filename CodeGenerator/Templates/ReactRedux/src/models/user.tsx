export interface User
{
    id : number,
    name : string,
    lastName : string,
    middleName : string,
    userPassword : string,
    login : string,
    email : string,
    jwt : string
}

export const initialUser : User = {
    id: 0,
    name: '',
    lastName: '',
    middleName: '',
    userPassword: '',
    login: '',
    email: '',
    jwt: ''
}