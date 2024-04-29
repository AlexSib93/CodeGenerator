export interface User
{
    id : number,
    name : string,
    lastName : string,
    middleName : string,
    phone : string,
    comment : string,
    userPassword : string,
    userLogin : string,
    email : string,
    jwt : string
}

export const initialUser : User = {
    id: 0,
    name: '',
    lastName: '',
    middleName: '',
    phone: '',
    comment: '',
    userPassword: '',
    userLogin: '',
    email: '',
    jwt: ''
}