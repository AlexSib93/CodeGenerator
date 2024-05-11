import { ModelMetadata, initModelMetadata } from "../models/ModelMetadata";
import ApiDataService from "./ApiDataService";

class ModelMetadataService {
  post(modelMetadata:ModelMetadata) {
    return ApiDataService.post('modelmetadata', 'create', modelMetadata)
      .then((response: any) => {
        return Promise.resolve(response.data);
      },
        (message) => Promise.reject(message));
  }

  get(idModelMetadata: number): Promise<ModelMetadata> {
    return ApiDataService.get('modelmetadata', `get?idModelMetadata=${idModelMetadata}`)
      .then(
        (response) => Promise.resolve(response.data),
        (message) => Promise.reject(message)
      );
  }
  
}

export default new ModelMetadataService();