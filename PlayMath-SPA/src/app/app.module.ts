import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// Base Components
import { NavbarComponent } from 'src/components/navbar/navbar.component';
import { ArticlesComponent } from 'src/components/articles/articles.component';
import { HomeComponent } from 'src/components/home/home.component';
import { LoginComponent } from 'src/components/login/login.component';
import { MathsComponent } from 'src/components/maths/maths.component';
import { ProfileComponent } from 'src/components/profile/profile.component';
import { QuestionsComponent } from 'src/components/questions/questions.component';
import { QuizComponent } from 'src/components/quiz/quiz.component';
import { RegisterComponent } from 'src/components/register/register.component';
import { ArticleFormComponent } from 'src/components/article-form/article-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

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
    ArticleFormComponent
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
