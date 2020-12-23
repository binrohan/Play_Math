import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Base Components
import { ArticleFormComponent } from './_components/article-form/article-form.component';
import { ArticleComponent } from './_components/article/article.component';
import { ArticlesComponent } from './_components/articles/articles.component';
import { HomeComponent } from './_components/home/home.component';
import { LoginComponent } from './_components/login/login.component';
import { MathsComponent } from './_components/maths/maths.component';
import { MeanComponent } from './_components/maths/mean/mean.component';
import { MedianComponent } from './_components/maths/median/median.component';
import { ModeComponent } from './_components/maths/mode/mode.component';
import { QuadraticComponent } from './_components/maths/quadratic/quadratic.component';
import { SquareComponent } from './_components/maths/square/square.component';
import { TrinomialComponent } from './_components/maths/trinomial/trinomial.component';
import { ProfileComponent } from './_components/profile/profile.component';
import { QuestionFormComponent } from './_components/question-form/question-form.component';
import { QuestionComponent } from './_components/question/question.component';
import { QuestionsComponent } from './_components/questions/questions.component';
import { QuizComponent } from './_components/quiz/quiz.component';
import { RegisterComponent } from './_components/register/register.component';
import { UserComponent } from './_components/user/user.component';
import { AuthService } from './_services/auth.service';

const routes: Routes = [
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [], // Here goes authguard
    children: [
      { path: '', component: HomeComponent },
      { path: 'home', component: HomeComponent },
      { path: 'articles', component: ArticlesComponent },
      { path: 'maths', component: MathsComponent },
      { path: 'maths/mean', component: MeanComponent },
      { path: 'maths/mode', component: ModeComponent },
      { path: 'maths/median', component: MedianComponent },
      { path: 'maths/trinomial', component: TrinomialComponent },
      { path: 'maths/quadratic', component: QuadraticComponent },
      { path: 'maths/square', component: SquareComponent },
      { path: 'profile', component: ProfileComponent },
      { path: 'questions', component: QuestionsComponent },
      { path: 'question/new', component: QuestionFormComponent, data: { roles: ['Admin', 'Reader', 'Writer'] } },
      { path: 'question/:id', component: QuestionComponent },
      { path: 'quiz', component: QuizComponent },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'articles/new', component: ArticleFormComponent, data: { roles: ['Admin', 'Writer'] } },
      { path: 'article/:id', component: ArticleComponent },
      { path: 'user/:id', component: UserComponent },
      { path: '**', component: HomeComponent }, // it will change in future
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
