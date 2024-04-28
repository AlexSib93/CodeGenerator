import axios from "axios";
import { Item } from "../models/item";

class SearchApiService {
  get(href: string, substring: string): Promise<Item[]> {
    return axios
      .get(href + "?substring=" + substring)
      .then((response) => {          
        return response.data;
      });
  }
}

export default new SearchApiService();