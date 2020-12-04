import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ArticleFormComponent } from 'src/components/article-form/article-form.component';
import { ArticlesComponent } from 'src/components/articles/articles.component';
import { HomeComponent } from 'src/components/home/home.component';
import { LoginComponent } from 'src/components/login/login.component';
import { MathsComponent } from 'src/components/maths/maths.component';
import { ProfileComponent } from 'src/components/profile/profile.component';
import { QuestionsComponent } from 'src/components/questions/questions.component';
import { QuizComponent } from 'src/components/quiz/quiz.component';
import { RegisterComponent } from 'src/components/register/register.component';

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
