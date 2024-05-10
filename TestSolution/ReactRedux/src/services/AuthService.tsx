import { Item } from "../models/item";
import { User } from "../models/user";
import ApiDataService from "./ApiDataService";

class AuthService {
  login(userlogin, userpassword) {
    var user = {
      userlogin,
      userpassword,
      email: ''
    };
    return ApiDataService.post('auth', 'login', user)
      .then((response: any) => {
        if (response.data.jwt) {
          localStorage.setItem("user", JSON.stringify(response.data));
        }
        return Promise.resolve(response.data);
      },
        (message) => {
          return Promise.reject(message)
        });
  }
  logout() {
    localStorage.removeItem("user");
  }
  register(user: User) {
    return ApiDataService.post('auth', 'register', user);
  }
  getCurrentUser(): User {
    return JSON.parse(localStorage.getItem('user'));
  }
  getCurrentUserItem(): Item {
    let res: Item
    let user: User
    let u = localStorage.getItem('user');
    if (u) {
      user = JSON.parse(localStorage.getItem('user'));
      res = { id: user.id, name: user.name };
    }

    return res;
  }
}
export default new AuthService();