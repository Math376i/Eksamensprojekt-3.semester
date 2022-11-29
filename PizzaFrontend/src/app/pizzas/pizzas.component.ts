import { Component, OnInit } from '@angular/core';

import {Pizza} from "../pizza";
import { PizzaService } from '../pizza.service';
@Component({
  selector: 'app-pizzas',
  templateUrl: './pizzas.component.html',
  styleUrls: ['./pizzas.component.css']
})
export class PizzasComponent implements OnInit {

  pizzas: Pizza[] = [];

  constructor(private pizzaService: PizzaService) { }

  ngOnInit(): void {
    this.getPizzas();
  }


  getPizzas(): void {
    this.pizzaService.getPizzas()
      .subscribe(pizzas => this.pizzas = pizzas);
  }

}
