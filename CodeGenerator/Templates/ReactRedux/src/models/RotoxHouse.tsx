export interface RotoxHouse {
  remoteStore: string;
  zoneCell: string;
  zoneRow: string;
  zoneStoreDepart: string;
  idRotoxHouse:number | null;
  storeDepart: string;
  row:string;
  cell:string;
  itemName:string;
  idManufactDoc:number | null;
  idManufactDocPos:number | null;
  manufactDocName:string;
  orderName:string;
  state:number;
  weight:number | null;
  logistDate:Date | null;
  destanationName:string;
  idOrderItem: number| null;
  idStoreDoc: number | null;
  orderItemNum: number | null;
  numPos: number | null;
  mfCntOnSgp: number;
  mfCntAll: number;
  idOrder: number;
  parentManufactDocName: string;
  parentIdManufactDoc:  number | null;
}

export const initialRotoxHouse : RotoxHouse = {
  idRotoxHouse: null,
  storeDepart: '',
  row: '',
  cell: '',
  itemName: '',
  idManufactDoc: null,
  idManufactDocPos: null,
  manufactDocName: '',
  orderName: '',
  state: 0,
  weight: null,
  logistDate: null,
  destanationName: '',
  idOrderItem: null,
  orderItemNum: null,
  numPos: null,
  mfCntOnSgp: 0,
  mfCntAll: 0,
  idStoreDoc: null,
  idOrder: 0,
  remoteStore: "",
  zoneCell: "",
  zoneRow: "",
  zoneStoreDepart: "",
  parentManufactDocName: "",
  parentIdManufactDoc: null
}
