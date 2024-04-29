import { User } from "../models/user";
import ApiDataService from "./ApiDataService";

class UserService {
  getAll(): Promise<User[]> {
    return ApiDataService.get('user', 'getall')
      .then((response) => {
        return Promise.resolve(response.data);
      });
  }
  update(user: User) {
    localStorage.removeItem("user");
  }
}
export default new UserService();