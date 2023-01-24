import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'; // <-- NgModel lives here
import { AppComponent } from './app.component';
import { PizzasComponent } from './pizzas/pizzas.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatInputModule} from "@angular/material/input";
import {MatCardModule} from "@angular/material/card";
import { LoginComponent } from './login/login.component';
import { PizzahandlerComponent } from './pizzahandler/pizzahandler.component';
import {RouterModule, RouterOutlet, Routes} from "@angular/router";
import {AuthguardService} from "./authguard.service";
import { RegisterComponent } from './register/register.component';


const routes: Routes = [
  {
    path: 'menu',component: PizzahandlerComponent, canActivate : [AuthguardService]
  },
  {
    path: 'login',component: LoginComponent
  },
  {
    path: 'register', component: RegisterComponent
  }
]
@NgModule({
  declarations: [
    AppComponent,
    PizzasComponent,
    LoginComponent,
    PizzahandlerComponent,
    RegisterComponent,


  ],
  imports: [
    BrowserModule,
    MatInputModule,
    FormsModule,
    BrowserAnimationsModule,
    MatCardModule,
    RouterOutlet,
    RouterModule.forRoot(routes),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
