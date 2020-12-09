import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Article } from 'src/app/_models/Article';
import { ArticleService } from 'src/app/_services/article.service';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.scss']
})
export class ArticleComponent implements OnInit {

  article: Article;
  articleId: number;

  constructor(private router: Router, private route: ActivatedRoute, private articleService: ArticleService) { }

  ngOnInit() {
    // this.tab = parseInt(this.route.snapshot.paramMap.get('tab'), 10);
    this.articleId = parseInt(this.route.snapshot.paramMap.get('id'), 10);
    this.getArticle();
  }

  getArticle(){
    this.articleService.getArticle(this.articleId).subscribe((data) => {
      this.article = data; console.log(this.article); console.log(this.article.body);
    }, (error) => {
      console.log('Article failed to load');
    });
  }
}
