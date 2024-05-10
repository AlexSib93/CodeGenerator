import { TestModel1, initTestModel1 } from "../models/TestModel1";
import ApiDataService from "./ApiDataService";

class TestModel1Service {
  post(testModel1:TestModel1) {
    return ApiDataService.post('testmodel1', 'create', testModel1)
      .then((response: any) => {
        return Promise.resolve(response.data);
      },
        (message) => Promise.reject(message));
  }

  get(idTestModel1: number): Promise<TestModel1> {
    return ApiDataService.get('testmodel1', `get?idTestModel1=${idTestModel1}`)
      .then(
        (response) => Promise.resolve(response.data),
        (message) => Promise.reject(message)
      );
  }
  
}

export default new TestModel1Service();