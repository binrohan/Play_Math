import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { NavbarComponent } from './assets/navbar/navbar.component';
import { AppComponent } from './app.component';
import { LandingComponent } from './pages/landing/landing.component';

import { from } from 'rxjs';
import { BgButtonComponent } from './assets/bg-button/bg-button.component';
import { HomeComponent } from './pages/home/home.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { HttpClientModule } from '@angular/common/http';
import { TrinomialComponent } from './pages/algebra/factor/trinomial/trinomial.component';
import { QuadraticComponent } from './pages/algebra/quadratic/quadratic.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    BgButtonComponent,
    LandingComponent,
    HomeComponent,
    TrinomialComponent,
    QuadraticComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
