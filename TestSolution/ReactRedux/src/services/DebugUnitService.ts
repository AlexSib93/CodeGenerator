import { DebugUnit, initDebugUnit } from "../models/DebugUnit";
import ApiDataService from "./ApiDataService";

class DebugUnitService {
  post(debugUnit:DebugUnit) {
    return ApiDataService.post('debugunit', 'create', debugUnit)
      .then((response: any) => {
        return Promise.resolve(response.data);
      },
        (message) => Promise.reject(message));
  }

  get(idDebugUnit: number): Promise<DebugUnit> {
    return ApiDataService.get('debugunit', `get?idDebugUnit=${idDebugUnit}`)
      .then(
        (response) => Promise.resolve(response.data),
        (message) => Promise.reject(message)
      );
  }
  
}

export default new DebugUnitService();