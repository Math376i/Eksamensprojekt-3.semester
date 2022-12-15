import {customAxios} from "../services/http.service";

export interface pizza {
  id: number;

  name: string;

  price : number

  almPrice : number;

  fam40x40Price : number;

  fam50x50Price : number;

  almGlutenfriPrice: number;

  topping: string;

  email: string;
}
