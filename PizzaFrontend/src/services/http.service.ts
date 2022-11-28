import { Injectable } from '@angular/core';
import axios from "axios";

export const customAxios = axios.create({baseURL: 'http://localhost:5104/'})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }

  async getAllPizzas(){
    const httpResponse = await customAxios.get<any>('pizza/GetAllPizzas')
    return httpResponse.data;
  }

  async createPizza(dto: { Pizzaname: string, AlmPrice: number, Fam40x40Price: number, Fam50x50Price: number, AlmGlutenfriPrice: number, Topping: string }) {
    const httpresult = await customAxios.post('pizza', dto);
    return httpresult.data;
  }

  async deletePizza(id: any) {
    const httpResult = await customAxios.delete('pizza/'+id)
    return httpResult.data;
  }


}
