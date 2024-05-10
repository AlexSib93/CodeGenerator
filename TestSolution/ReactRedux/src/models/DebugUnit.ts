export interface DebugUnit {
  name:string;
  id:number;
  count:number | null;
  date:Date;
}

export const initDebugUnit = {
  name:'',
  id:0,
  count:null,
  date:new Date(),

}
