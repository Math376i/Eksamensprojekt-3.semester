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
    const httpResult = await customAxios.post('Pizza/CreatePizza', dto);
    return httpResult.data;
  }

  async deletePizza(id: any) {
    const httpResult = await customAxios.delete('Pizza/DeletePizza'+id)
    return httpResult.data;
  }

  async pizzaToOrder(dto: {PizzaName: string, AlmPrice: number, Fam40x40Price: number, Fam50x50Price: number, AlmGlutenfriPrice: number, Topping: string}) {
    const httpResult = await customAxios.post('Pizza/AddPizzaToOrder'+dto);
    return httpResult.data;
  }

  async getPizzasFromOrder() {
    const httpResult = await customAxios.get('Pizza/GetPizzaFromOrder')
    return httpResult.data;
  }

  async deletePizzaFromOrder(id: any) {
    const httpResult = await customAxios.delete('Pizza/DeletePizzaFromOrder'+id)
    return httpResult.data;
  }

}
