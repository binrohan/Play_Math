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
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';

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
    FormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
