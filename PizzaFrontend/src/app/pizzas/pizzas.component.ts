import { Component, OnInit } from '@angular/core';

import {Pizza} from "../pizza";
import { PizzaService } from '../pizza.service';
import { MessageService } from '../message.service';
@Component({
  selector: 'app-pizzas',
  templateUrl: './pizzas.component.html',
  styleUrls: ['./pizzas.component.css']
})
export class PizzasComponent implements OnInit {

  selectedPizza?: Pizza;

  pizzas: Pizza[] = [];

  constructor(private pizzaService: PizzaService, private messageService: MessageService) { }

  ngOnInit(): void {
    this.getPizzas();
  }

  onSelect(pizza: Pizza): void {
    this.selectedPizza = pizza;
    this.messageService.add(`PizzasComponent: Selected pizza id=${pizza.id}`);
  }

  getPizzas(): void {
    this.pizzaService.getPizzas()
      .subscribe(pizzas => this.pizzas = pizzas);
  }

}
