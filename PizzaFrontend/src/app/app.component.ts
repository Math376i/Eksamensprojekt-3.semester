import { Component } from '@angular/core';
import {HttpService} from "../services/http.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  PizzaName: string ="";
  Pizzas: any;
  AlmPrice: number = 0;
  Fam40x40Price: number = 0;
  Fam50x50Price: number = 0;
  AlmGlutenfriPrice: number = 0;
  Topping: string = "";

  constructor(private http: HttpService) {

  }

  async ngOnInit() {
    const Pizzas = await this.http.getAllPizzas();
    this.Pizzas = Pizzas;
  }

  async createPizza(){
    let dto = {
      PizzaName: this.PizzaName,
      AlmPrice: this.AlmPrice,
      Fam40x40Price: this.Fam40x40Price,
      Fam50x50Price: this.Fam50x50Price,
      AlmGlutenfriPrice: this.AlmGlutenfriPrice,
      Topping: this.Topping
    }
    const result = await this.http.createPizza(dto)
    this.Pizzas.push(result)
  }

  async deletePizzas(id: any) {
    const pizza = await this.http.deletePizza(id);
    this.Pizzas = this.Pizzas.filter((b: { id: any; }) => b.id != pizza.id)
  }

}
