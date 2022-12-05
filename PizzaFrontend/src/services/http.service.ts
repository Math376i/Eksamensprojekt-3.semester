import { Injectable } from '@angular/core';
import axios from "axios";
import {pizza} from "../app/pizza";

export const customAxios = axios.create({baseURL: 'http://localhost:5001/'})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() {
  }

  async getAllPizzas(){
    const httpResult = await customAxios.get<any>('Pizza/GetAllPizzas')
    return httpResult.data;
  }

  async createPizza(dto: { PizzaName: string, AlmPrice: number, Fam40x40Price: number, Fam50x50Price: number, AlmGlutenfriPrice: number, Topping: string }) {
    const httpResult = await customAxios.post('Pizza', dto);
    return httpResult.data;
  }

  async deletePizza(id: any) {
    const httpResult = await customAxios.delete('Pizza/'+id)
    return httpResult.data;
  }


}
