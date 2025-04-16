import axios from "axios";
import { useContext } from "react";
import { API_URL, LOGIN_PAGE_URL } from "../constants";
import { ContextApp } from "../state/state";
import AuthService from "./AuthService";

class ApiDataService {
  
  post(controller: string, meth: string, data?: any) {
    return axios
      .post(`${API_URL}${controller}/${meth}`, data)
      .catch((error: any) => {
        let message = '';
        if (error.response) {
          if (error.response.data) {
            message = error.response.data;
          }

          if (error.response.status == 401) {
            message = 'Ошибка авторизации. Требуется повторный вход';
            AuthService.logout();
            window.location.replace(LOGIN_PAGE_URL);
          }

        } else {
          message = error.message;
        }
        console.error(error);
        return Promise.reject(message);
      });
  }

  put(controller: string, meth: string, data?: any) {
    return axios
      .put(`${API_URL}${controller}/${meth}`, data)
      .catch((error: any) => {
        let message = '';
        if (error.response) {
          if (error.response.data) {
            message = error.response.data;
          }

          if (error.response.status == 401) {
            message = 'Ошибка авторизации. Требуется повторный вход';
            AuthService.logout();
            window.location.replace(LOGIN_PAGE_URL);
          }

        } else {
          message = error.message;
        }
        console.error(error);
        return Promise.reject(message);
      });
  }

  delete(controller: string, meth: string, id: any) {
    return axios
      .delete(`${API_URL}${controller}/${meth}?id=${id}`)
      .catch((error: any) => {
        let message = '';
        if (error.response) {
          if (error.response.data) {
            message = error.response.data;
          }

          if (error.response.status == 401) {
            message = 'Ошибка авторизации. Требуется повторный вход';
            AuthService.logout();
            window.location.replace(LOGIN_PAGE_URL);
          }

        } else {
          message = error.message;
        }
        console.error(error);
        return Promise.reject(message);
      });
  }

  get(controller: string, meth: string, params: string = "") {
    return axios
      .get(`${API_URL}${controller}/${meth}?${params}`)
      .catch((error: any) => {
        let message = '';
        if (error.response) {
          if (error.response.data) {
            message = error.response.data;
          }

          if (error.response.status == 401) {
            AuthService.logout();
          }

        } else {
          message = error.message;
        }
        console.error(error);

        return Promise.reject(message);
      });
  }
}

export default new ApiDataService();