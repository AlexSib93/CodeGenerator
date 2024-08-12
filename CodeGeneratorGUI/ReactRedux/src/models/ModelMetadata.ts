import { PropMetadata } from "./PropMetadata";
export interface ModelMetadata {
  name:string;
  nameSpace:string;
  caption:string;
  props:PropMetadata[];
}

export const initModelMetadata = {
  name:'',
  nameSpace:'',
  caption:'',
  props:[],

}
