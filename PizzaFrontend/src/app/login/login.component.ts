import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../services/http.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  email: any;
  password: any;

  constructor(private http: HttpService, private router: Router) { }

  ngOnInit(): void {
  }

  async login() {
    let dto = {
     email: this.email,
      password: this.password
    }
    var token = await this.http.login(dto);
    localStorage.setItem('token',token)
    this.router.navigate(['/menu'])
  }


  register() {
    this.router.navigate(['/register'])
  }
}
