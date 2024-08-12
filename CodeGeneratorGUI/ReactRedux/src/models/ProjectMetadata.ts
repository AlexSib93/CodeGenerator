import { ModelMetadata } from "./ModelMetadata";
import { FormMetadata } from "./FormMetadata";
export interface ProjectMetadata {
  name:string;
  description:string;
  path:string;
  models:ModelMetadata[];
  forms:FormMetadata[];
}

export const initProjectMetadata = {
  name:'',
  description:'',
  path:'',
  models:[],
  forms:[],

}
