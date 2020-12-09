// Node Modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {  HttpClientModule } from '@angular/common/http';

// Others
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// Base Components
import { ArticlesComponent } from './_components/articles/articles.component';
import { HomeComponent } from './_components/home/home.component';
import { LoginComponent } from './_components/login/login.component';
import { MathsComponent } from './_components/maths/maths.component';
import { NavbarComponent } from './_components/navbar/navbar.component';
import { ProfileComponent } from './_components/profile/profile.component';
import { QuestionsComponent } from './_components/questions/questions.component';
import { QuizComponent } from './_components/quiz/quiz.component';
import { RegisterComponent } from './_components/register/register.component';

// Base Services
import { AuthService } from './_services/auth.service';
import { UserService } from './_services/user.service';
import { ArticleService } from './_services/article.service';
import { QuizService } from './_services/quiz.service';
import { QuestionService } from './_services/question.service';

// Secondary Component
import { ArticleComponent } from './_components/article/article.component';
import { ArticleFormComponent } from './_components/article-form/article-form.component';


// Pipes
import { SummaryPipe } from './_pipes/summary.pipe';
import { NewLinePipe } from './_pipes/newLine.pipe';


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
    ArticleComponent,
    SummaryPipe,
    NewLinePipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    AuthService,
    UserService,
    ArticleService,
    QuizService,
    QuestionService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
