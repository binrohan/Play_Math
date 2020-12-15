import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Category } from 'src/app/_models/Category';
import { ArticleService } from 'src/app/_services/article.service';
import { AuthService } from 'src/app/_services/auth.service';
import { QuestionService } from 'src/app/_services/question.service';

@Component({
  selector: 'app-question-form',
  templateUrl: './question-form.component.html',
  styleUrls: ['./question-form.component.scss'],
})
export class QuestionFormComponent implements OnInit {

  question: any = {};
  categories: Category[];
  questionForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private articleService: ArticleService,
    private questionService: QuestionService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.createQuestionForm();
    this.getCategories();
  }

  createQuestionForm() {
    this.questionForm = this.fb.group({
      title: ['', Validators.required],
      categoryId: ['', Validators.required],
      body: ['', Validators.required],
    });
  }

  addQuestion(){
    console.log(this.questionForm.value);
  }

  getCategories() {
    this.articleService.getCategories().subscribe(
      (data) => {
        this.categories = data;
      },
      (error) => {
        console.log('Failed during getCategories');
      }
    );
  }
}
