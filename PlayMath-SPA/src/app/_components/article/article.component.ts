import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Article } from 'src/app/_models/Article';
import { ArticleService } from 'src/app/_services/article.service';
import { faHeart, faThumbsUp } from '@fortawesome/free-solid-svg-icons';
import { CommentService } from 'src/app/_services/comment.service';
import { AuthService } from 'src/app/_services/auth.service';
import { ArticleComment } from 'src/app/_models/article-comment';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.scss'],
})
export class ArticleComponent implements OnInit {
  faThumbsUp = faThumbsUp;
  faHeart = faHeart;

  article: Article;
  articleId: number;


  isLiked = false;
  likeCount = 69;

  allComments: ArticleComment[];

  model: any = {};


  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private articleService: ArticleService,
    private commentService: CommentService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.articleId = parseInt(this.route.snapshot.paramMap.get('id'), 10);
    this.getArticle();
  }

  getArticle() {
    this.articleService.getArticle(this.articleId).subscribe(
      (data) => {
        this.article = data;
        console.log('Article Load Successfully');
        this.getComments();
      },
      (error) => {
        console.log('Article failed to load');
      }
    );
  }

  postComment() {
    if (this.model.commentText !== '' || this.model.commentText !== undefined){

      this.model.commentDate = new Date();
      this.model.commenterId = this.authService.decodedToken.nameid;
      this.model.articleId = this.article.id;
      this.commentService.addComment(this.model).subscribe(() => {
        this.getComments();
        console.log('comment posted');
      }, error => {
        console.log('Comment post failed');
      });
    }
  }

  getComments(){
    this.commentService.getComments(this.article.id).subscribe((data) => {
      this.allComments = data;
      console.log('comments loaded successfully');
    }, (error) => {
      console.log('Failed load comments');
    });
  }

  onLike() {
    this.isLiked = !this.isLiked;
    if (!this.isLiked) {
      this.likeCount--;
    } else {
      this.likeCount++;
    }
  }
}
