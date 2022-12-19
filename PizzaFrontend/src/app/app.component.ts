import {Component, OnInit} from '@angular/core';
import {HttpService} from "../services/http.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  MenuPizzas: any;
  pizzasOrdered: any;
  PizzaName: string ="";
  AlmPrice : number = 0;
  Fam40x40Price : number = 0;
  Fam50x50Price : number= 0;
  AlmGlutenfriPrice: number = 0;
  Topping: string = "";
  Email: string = "";

  constructor(private http: HttpService) {

  }

  ngOnInit(): void {

    this.GetAllPizzas();
    this.pizzaToOrder

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
    this.MenuPizzas.push(result)
  }

  async deletePizzas(id: any) {
    const pizza = await this.http.deletePizza(id);
    this.MenuPizzas = this.MenuPizzas.filter((b: { id: any; }) => b.id != pizza.id)
  }

  async GetAllPizzas(){
    this.MenuPizzas = await this.http.GetAllPizzas()
  }

  async pizzaToOrder(){
     let dto = {
     PizzaName: this.PizzaName,
       AlmPrice: this.AlmPrice,
     Fam40x40Price: this.Fam40x40Price,
     Fam50x50Price: this.Fam50x50Price,
     AlmGlutenfriPrice: this.AlmGlutenfriPrice,
      Topping: this.Topping
    }
    const result = await this.http.GetPizzaFromOrder()
    this.pizzasOrdered.push(result)
   }

  async deletePizzaFromOrder(id: any) {
    const pizza = await this.http.deletePizzaFromOrder(id);
    this.pizzasOrdered = this.pizzasOrdered.filter((p: {id:any;}) => p.id != pizza.id)
  }

}
