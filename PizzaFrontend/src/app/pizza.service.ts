import { Injectable } from '@angular/core';
import { Pizza } from './pizza';
import {PIZZAS} from './mock-pizzas';
import { Observable, of } from 'rxjs';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class PizzaService {

  constructor(private messageService: MessageService) { }

  getPizzas(): Observable<Pizza[]> {
    const pizzas = of(PIZZAS);
    this.messageService.add('PizzaService: fetched heroes');
    return pizzas;
  }
}
