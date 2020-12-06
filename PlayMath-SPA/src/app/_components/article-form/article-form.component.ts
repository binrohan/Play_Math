import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Category } from 'src/app/_models/Category';
import { ArticleService } from 'src/app/_services/article.service';

@Component({
  selector: 'app-article-form',
  templateUrl: './article-form.component.html',
  styleUrls: ['./article-form.component.scss'],
})
export class ArticleFormComponent implements OnInit {
  articleForm: FormGroup;
  categories: Category[];
  article: {};

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private articleService: ArticleService
  ) {}

  ngOnInit() {
    this.createArticleForm();
    this.getCategories();
  }

  createArticleForm() {
    this.articleForm = this.fb.group({
      title: ['', Validators.required],
      subtitle: ['', Validators.maxLength(25)],
      category: ['', Validators.required],
      body: ['', Validators.required],
    });
  }

  addArticle() {
    if (this.articleForm.valid) {
      this.article = Object.assign({}, this.articleForm.value);
      this.articleService.addArticle(this.article).subscribe(
        () => {
          console.log('Article added successfully');
        },
        (error) => {
          console.log('Article added failed');
        }
      );
    }
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
