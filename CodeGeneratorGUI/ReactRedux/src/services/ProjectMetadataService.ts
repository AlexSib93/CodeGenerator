import { ProjectMetadata, initProjectMetadata } from "../models/ProjectMetadata";
import ApiDataService from "./ApiDataService";

class ProjectMetadataService {
  post(projectMetadata:ProjectMetadata) {
    return ApiDataService.post('projectmetadata', 'create', projectMetadata)
      .then((response: any) => {
        return Promise.resolve(response.data);
      },
        (message) => Promise.reject(message));
  }

  get(idProjectMetadata: number): Promise<ProjectMetadata> {
    return ApiDataService.get('projectmetadata', `get?idProjectMetadata=${idProjectMetadata}`)
      .then(
        (response) => Promise.resolve(response.data),
        (message) => Promise.reject(message)
      );
  }
  
  getall(): Promise<ProjectMetadata[]> {
    return ApiDataService.get('projectmetadata', `getall`)
      .then(
        (response) => Promise.resolve(response.data),
        (message) => Promise.reject(message)
      );
  }
}

export default new ProjectMetadataService();