// Node Modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

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
import { QuestionFormComponent } from './_components/question-form/question-form.component';
import { QuestionComponent } from './_components/question/question.component';
import { MeanComponent } from './_components/maths/mean/mean.component';
import { ModeComponent } from './_components/maths/mode/mode.component';
import { MedianComponent } from './_components/maths/median/median.component';
import { QuadraticComponent } from './_components/maths/quadratic/quadratic.component';
import { TrinomialComponent } from './_components/maths/trinomial/trinomial.component';

// Pipes
import { SummaryPipe } from './_pipes/summary.pipe';
import { NewLinePipe } from './_pipes/newLine.pipe';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { JwtModule } from '@auth0/angular-jwt';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UserComponent } from './_components/user/user.component';
import { AuthGuard } from './_guards/auth.guard';
import { HasRoleDirective } from './_directives/hasRole.directive';

// Materials
// import {MatListModule} from '@angular/material/list';
// import {MatSelectModule} from '@angular/material/select';

export function tokenGetter() {
  return localStorage.getItem('token');
}

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
    QuestionFormComponent,
    QuestionComponent,
    QuizComponent,
    RegisterComponent,
    ArticleFormComponent,
    ArticleComponent,
    SummaryPipe,
    NewLinePipe,
    MeanComponent,
    ModeComponent,
    MedianComponent,
    QuadraticComponent,
    TrinomialComponent,
    UserComponent,
    HasRoleDirective
    // Material
    // MatListModule,
    // MatSelectModule
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    FontAwesomeModule,

    JwtModule.forRoot({
      config: {
        tokenGetter,
        allowedDomains: ['localhost:5000'],
        disallowedRoutes: ['localhost:5000/api/auth'],
      },
    }),

    BrowserAnimationsModule,
  ],
  providers: [
    AuthService,
    UserService,
    ArticleService,
    QuizService,
    QuestionService,
    AuthGuard,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
