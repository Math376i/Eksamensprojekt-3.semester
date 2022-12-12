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

  pizzas: any;
  pizzasOrdered: any;

  constructor(private pizzaService: PizzaService, private httpService: HttpService) { }

  ngOnInit(): void {
    this.getPizzas();
    this.getPizzasOrdered();
  }


  async getPizzas() {
   this.pizzas = await this.httpService.getAllPizzas()
  }

  async getPizzasOrdered() {
    this.pizzasOrdered = await this.httpService.getPizzaFromOrder()
  }

}
