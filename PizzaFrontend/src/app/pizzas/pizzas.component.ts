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
  pizzasOrdered: any;
  PizzaName: string ="";
  AlmPrice : number = 0;
  Fam40x40Price : number = 0;
  Fam50x50Price : number= 0;
  AlmGlutenfriPrice: number = 0;
  Topping: string = "";
  Email: string = "";

  constructor(private pizzaService: PizzaService, private httpService: HttpService) { }

  ngOnInit(): void {
    this.getPizzas();

  }

  async getPizzas() {
   this.MenuPizzas = await this.httpService.getAllPizzas()
  }

  async add(price: number) {

     // this.pizzasOrdered = await this.httpService.getPizzasFromOrder()

      let dto = {
        PizzaName: this.PizzaName,
        AlmPrice: this.AlmPrice,
        Fam40x40Price: this.Fam40x40Price,
        Fam50x50Price: this.Fam50x50Price,
        AlmGlutenfriPrice: this.AlmGlutenfriPrice,
        Topping: this.Topping
      }
      this.pizzasOrdered.push()
  }

  async buy(price: number) {

  }
}
