import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { NavbarComponent } from './assets/navbar/navbar.component';
import { AppComponent } from './app.component';
import { LandingComponent } from './pages/landing/landing.component';

import { from } from 'rxjs';
import { BgButtonComponent } from './assets/bg-button/bg-button.component';
import { HomeComponent } from './pages/home/home.component';
import { FactorizeComponent } from './pages/factorize/factorize.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    BgButtonComponent,
    LandingComponent,
    HomeComponent,
    FactorizeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
