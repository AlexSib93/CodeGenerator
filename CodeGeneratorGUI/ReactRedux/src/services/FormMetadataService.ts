import { FormMetadata, initFormMetadata } from "../models/FormMetadata";
import ApiDataService from "./ApiDataService";

class FormMetadataService {
  post(formMetadata:FormMetadata) {
    return ApiDataService.post('formmetadata', 'create', formMetadata)
      .then((response: any) => {
        return Promise.resolve(response.data);
      },
        (message) => Promise.reject(message));
  }

  get(idFormMetadata: number): Promise<FormMetadata> {
    return ApiDataService.get('formmetadata', `get?idFormMetadata=${idFormMetadata}`)
      .then(
        (response) => Promise.resolve(response.data),
        (message) => Promise.reject(message)
      );
  }
  
}

export default new FormMetadataService();