import {customAxios} from "../services/http.service";

export interface pizza {
  id: number;
  name: string;
  AlmPrice: number;
  Fam40x40Price: number;
  Fam50x50Price: number;
  AlmGlutenfriPrice: number;
  Topping: string;
}
