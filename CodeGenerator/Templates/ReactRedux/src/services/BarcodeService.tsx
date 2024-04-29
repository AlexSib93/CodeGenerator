import axios from "axios";
import { API_URL } from "../constants";
import { OrderItem } from "../models/OrderItem";

class BarcodeService {
  scan(barcode: string): Promise<OrderItem> {
    return axios
      .post(`${API_URL}barcode/scan?barcode=${barcode}`)
      .then(
        (response) => Promise.resolve(response.data),
        (message) => Promise.reject(message)
      );
  }

}
export default new BarcodeService();