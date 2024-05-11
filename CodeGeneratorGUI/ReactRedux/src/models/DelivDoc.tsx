export interface DelivDoc {
  idDelivDoc:number;
  name:string;
  driverName: string;
  carNumber: string;
}

export const initialDelivDoc : DelivDoc = {
  idDelivDoc: 0,
  name: '',
  driverName: "",
  carNumber: ""
}
