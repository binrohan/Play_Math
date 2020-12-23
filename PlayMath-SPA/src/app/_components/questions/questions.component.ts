import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/_models/Category';
import { Question } from 'src/app/_models/Question';
import { ArticleService } from 'src/app/_services/article.service';
import { AuthService } from 'src/app/_services/auth.service';
import { QuestionService } from 'src/app/_services/question.service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.scss'],
})
export class QuestionsComponent implements OnInit {
  categories: Category[];
  questions: Question[];

  activeCate = 0;
  totalPage = [];

  params = {
    pageIndex: 0,
    pageSize: 5,
    filter: '',
    categoryBy: 0,
    byUserId: '',
  };

  filter = '';

  constructor(
    private articleService: ArticleService,
    private questionService: QuestionService,
    private router: Router,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.getCategories();
    this.getQuestions();
  }

  getCategories() {
    this.articleService.getCategories().subscribe(
      (data) => {
        this.categories = data;
      },
      (error) => {
        console.log('Failed to get categories');
      }
    );
  }

  getQuestions() {
    this.questionService.getQuestions(this.params).subscribe(
      (data) => {
        this.questions = data.questions;
        this.pageCalc(data.length);
        console.log(this.questions);
      },
      (error) => {
        console.log('Failed to get Question');
      }
    );
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  onCategoryChange(category: Category) {
    this.activeCate = category.id;
    this.params.categoryBy = category.id;
    this.getQuestions();
  }

  onPageChange(index) {
    this.params.pageIndex = index;
    this.getQuestions();
  }

  goToQuestion(id) {
    this.router.navigate(['/question/' + id]);
  }

  pageCalc(length: number) {
    this.totalPage = Array(Math.ceil(length / this.params.pageSize))
      .fill(1)
      .map((x, i) => i);
  }

  onSearch() {
    this.params.filter = this.filter;
    this.getQuestions();
  }
}
