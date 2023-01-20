import { Injectable } from '@angular/core';
import axios from "axios";
import {pizza} from "../app/pizza";

export const customAxios = axios.create({baseURL: 'https://localhost:5000/'})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() {
  }

  async GetAllPizzas(){
    const httpResult = await customAxios.get('Pizza/GetAllPizzas')
    return httpResult.data;
  }

  async GetPizzaFromOrder(){
    const httpResult = await customAxios.get<any>('Pizza/GetPizzaFromOrder')
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

  async GetAllOrders(){
    const httpResult = await customAxios.get('Pizza/GetAllOrders')
    return httpResult.data;
  }

  async CreateNewOrder(){
    const httpResult = await customAxios.post('Pizza/CreateNewOrder')
  }

  async deletePizzaFromOrder(id: any) {
    const httpResult = await customAxios.delete('Pizza/DeletePizzaFromOrder'+id)
    return httpResult.data;
  }

  async sendOrder(dto: any){
    const httpResult = await customAxios.post('Pizza/CreateNewPizzaOrder',dto)
    return httpResult.data;
  }


}
