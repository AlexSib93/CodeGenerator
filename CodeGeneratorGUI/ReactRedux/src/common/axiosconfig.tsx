import axios from 'axios';
import {Service} from 'axios-middleware';
import { User } from '../models/user';

export const AxiosConfigure = () => {
    const service = new Service(axios);
    service.register({
      onRequest: (config: any) => {
        //config.url = `${PUBLIC_URL}${config.url}`;
        let userData:User = JSON.parse(localStorage.getItem("user"));
        if(userData){
          config.headers['Authorization'] = `Bearer ${userData.jwt}`;
        }
        if (config.method == 'post' || config.method == 'put') {
          config.headers['Accept'] = `application/json`;
          config.headers['Content-Type'] = `application/json`;
        }
  
        return config;
      }
    });
  };