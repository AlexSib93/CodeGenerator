export interface Order {
    state: string
    idOrder : number,
    name: string
}

export const initialOrder : Order = {
    idOrder: 0,
    name: '',
    state: ""
}