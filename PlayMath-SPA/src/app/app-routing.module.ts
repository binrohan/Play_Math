import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Base Components
import { ArticleFormComponent } from './_components/article-form/article-form.component';
import { ArticlesComponent } from './_components/articles/articles.component';
import { HomeComponent } from './_components/home/home.component';
import { LoginComponent } from './_components/login/login.component';
import { MathsComponent } from './_components/maths/maths.component';
import { ProfileComponent } from './_components/profile/profile.component';
import { QuestionsComponent } from './_components/questions/questions.component';
import { QuizComponent } from './_components/quiz/quiz.component';
import { RegisterComponent } from './_components/register/register.component';


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
      { path: 'profile', component: ProfileComponent },
      { path: 'questions', component: QuestionsComponent },
      { path: 'quiz', component: QuizComponent },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'articles/new', component: ArticleFormComponent },
      { path: '**', component: HomeComponent }, // it will change in future
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
