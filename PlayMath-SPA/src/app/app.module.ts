import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// Base Components
import { ArticleFormComponent } from './_components/article-form/article-form.component';
import { ArticlesComponent } from './_components/articles/articles.component';
import { HomeComponent } from './_components/home/home.component';
import { LoginComponent } from './_components/login/login.component';
import { MathsComponent } from './_components/maths/maths.component';
import { NavbarComponent } from './_components/navbar/navbar.component';
import { ProfileComponent } from './_components/profile/profile.component';
import { QuestionsComponent } from './_components/questions/questions.component';
import { QuizComponent } from './_components/quiz/quiz.component';
import { RegisterComponent } from './_components/register/register.component';




@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ArticlesComponent,
    HomeComponent,
    LoginComponent,
    MathsComponent,
    ProfileComponent,
    QuestionsComponent,
    QuizComponent,
    RegisterComponent,
    ArticleFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
