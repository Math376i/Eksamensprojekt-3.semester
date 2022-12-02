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

  constructor(private pizzaService: PizzaService, private httpService: HttpService) { }

  ngOnInit(): void {
    this.getPizzas();
  }


  async getPizzas() {
   this.pizzas = await this.httpService.getAllPizzas()
  }

}
