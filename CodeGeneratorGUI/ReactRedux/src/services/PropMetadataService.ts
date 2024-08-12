import { PropMetadata, initPropMetadata } from "../models/PropMetadata";
import ApiDataService from "./ApiDataService";

class PropMetadataService {
  post(propMetadata:PropMetadata) {
    return ApiDataService.post('propmetadata', 'create', propMetadata)
      .then((response: any) => {
        return Promise.resolve(response.data);
      },
        (message) => Promise.reject(message));
  }

  get(idPropMetadata: number): Promise<PropMetadata> {
    return ApiDataService.get('propmetadata', `get?idPropMetadata=${idPropMetadata}`)
      .then(
        (response) => Promise.resolve(response.data),
        (message) => Promise.reject(message)
      );
  }
  
  getall(): Promise<PropMetadata[]> {
    return ApiDataService.get('propmetadata', `getall`)
      .then(
        (response) => Promise.resolve(response.data),
        (message) => Promise.reject(message)
      );
  }
}

export default new PropMetadataService();