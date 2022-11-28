import {Component, Input, OnInit} from '@angular/core';
import { Pizza } from '../pizza';

@Component({
  selector: 'app-pizza-detail',
  templateUrl: './pizza-detail.component.html',
  styleUrls: ['./pizza-detail.component.css']
})
export class PizzaDetailComponent implements OnInit {
  @Input() pizza?: Pizza;

  constructor() { }

  ngOnInit(): void {
  }

}
