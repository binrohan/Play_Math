import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Article } from 'src/app/_models/Article';
import { Category } from 'src/app/_models/Category';
import { ArticleService } from 'src/app/_services/article.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-article-form',
  templateUrl: './article-form.component.html',
  styleUrls: ['./article-form.component.scss'],
})
export class ArticleFormComponent implements OnInit {
  articleForm: FormGroup;
  categories: Category[];
  article: Article;
  bodyText: string;
  newArticle: any = {};

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private articleService: ArticleService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.createArticleForm();
    this.getCategories();
  }

  createArticleForm() {
    this.articleForm = this.fb.group({
      title: ['', Validators.required],
      subtitle: ['', Validators.maxLength(150)],
      categoryId: ['', Validators.required],
      body: ['', Validators.required],
    });
  }

  addArticle() {
    if (this.articleForm.valid) {

      this.bodyText = this.articleForm.controls.body.value;
      this.bodyText = this.bodyText.replace('/(?:\r\n|\r|\n)/g', '<br>');

      this.article = Object.assign({}, this.articleForm.value);

      this.article.published = new Date();
      this.article.writerId = this.authService.decodedToken.nameid;

      this.articleService.addArticle(this.article).subscribe(
        (data) => {
          console.log('Article added successfully');
          this.newArticle = data;
          this.router.navigate(['article/' + this.newArticle.id]);
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
