import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../services/http.service";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent  implements OnInit {
  email: any;
  password: any;

  constructor(private http: HttpService) { }

  ngOnInit(): void {
  }

  async register() {
    let dto = {
      email: this.email,
      password: this.password,
      role: 'User'
    }
    var token = await this.http.register(dto);
    localStorage.setItem('token',token)
  }
}



