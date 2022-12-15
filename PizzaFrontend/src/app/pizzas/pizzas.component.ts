import { Component, OnInit } from '@angular/core';

import {pizza} from "../pizza";
import { PizzaService } from '../pizza.service';
import {HttpService} from "../../services/http.service";
@Component({
  selector: 'app-pizzas',
  templateUrl: './pizzas.component.html',
  styleUrls: ['./pizzas.component.css']
})
export class PizzasComponent implements OnInit {

  MenuPizzas: any;
  CustomerInfo: any;
  pizzasOrdered: any []= [];

  PizzaName: string ="";
  AlmPrice : number = 0;
  price: number = 0;
  Fam40x40Price : number = 0;
  Fam50x50Price : number= 0;
  AlmGlutenfriPrice: number = 0;
  Topping: string = "";
  Email: string = "";

  constructor(private pizzaService: PizzaService, private httpService: HttpService) { }

  ngOnInit(): void {

    this.GetAllPizzas();
  }

  async GetAllPizzas(){
   this.MenuPizzas = await this.httpService.GetAllPizzas()
  }


  async GetPizzaFromOrder(){
    this.pizzasOrdered = await this.httpService.GetPizzaFromOrder()
  }

  async add(id: number, name: string, price: number ) {

      let dto = {
        id,
        name,
        price
      }

      this.pizzasOrdered.push(dto)
  }

  async buy (CustomerName: string, PhoneNumber: number, Email: string) {

    let customer = {
    CustomerName,
    PhoneNumber,
    Email
    }
    await this.httpService.CreateNewOrder()
     // @ts-ignore
    this.pizzasOrdered.map(this.Email = customer.Email);
  }
}
