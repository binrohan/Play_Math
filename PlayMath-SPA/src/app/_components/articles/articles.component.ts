import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Article } from 'src/app/_models/Article';
import { ArticleParams } from 'src/app/_models/ArticleParams';
import { Category } from 'src/app/_models/Category';
import { ArticleService } from 'src/app/_services/article.service';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.scss'],
})
export class ArticlesComponent implements OnInit {
  categories: Category[];
  articles: Article[];
  articleParams: ArticleParams = {
    pageIndex: 0,
    pageSize: 6,
    filter: '',
    categoryBy: 0
  };

  constructor(private articleService: ArticleService, private router: Router) {}

  ngOnInit() {
    this.getCategories();
    this.getArticles();
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

  getArticles() {
    this.articleService.getArticles(this.articleParams).subscribe(
      (data) => {
        this.articles = data;
        console.log(this.articles);
      },
      (error) => {
        console.log('Failed to get articles');
      }
    );
  }

  getArticlesByCategory(category: Category) {
    this.articleParams.categoryBy = category.id;
    this.getArticles();
  }

  goToArticle(article) {
    console.log(article.id);
    this.router.navigate(['/article/' + article.id]);
  }
}
