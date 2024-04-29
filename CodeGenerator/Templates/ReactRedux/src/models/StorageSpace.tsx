export interface StorageSpace {
  idStorageSpace: number;
  row: string;
  cell: string;
  barcode: string;
  storeName: string;
  parent : StorageSpace;
}

export const initialStorageSpace: StorageSpace = {
  idStorageSpace: 0,
  row: '',
  cell: '',
  barcode: '',
  storeName: '',
  parent: null
}
