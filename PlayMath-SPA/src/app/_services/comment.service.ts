import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ArticleComment } from '../_models/article-comment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  baseUrl = environment.apiUrl + 'comment/';

constructor(private http: HttpClient) { }

  getComments(articleId: number) {
    return this.http.get<ArticleComment[]>(this.baseUrl + articleId);
  }

  addComment(comment: {}){
    return this.http.post(this.baseUrl, comment);
  }
}
