import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ArticlesComponent } from 'src/components/articles/articles.component';
import { HomeComponent } from 'src/components/home/home.component';
import { MathsComponent } from 'src/components/maths/maths.component';
import { ProfileComponent } from 'src/components/profile/profile.component';
import { QuestionsComponent } from 'src/components/questions/questions.component';
import { QuizComponent } from 'src/components/quiz/quiz.component';

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
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
