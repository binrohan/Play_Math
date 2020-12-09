import { HttpClient, HttpClientModule, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Article } from '../_models/Article';
import { Category } from '../_models/Category';

@Injectable({
  providedIn: 'root',
})
export class ArticleService {
  baseUrl = environment.apiUrl + 'article';

  constructor(private http: HttpClient) {}

  getCategories() {
    return this.http.get<Category[]>(this.baseUrl + '/categories');
  }

  addArticle(article: {}) {
    return this.http.post(this.baseUrl, article);
  }

  getArticles(articleParams) {
    let params = new HttpParams();

    if (articleParams != null) {
      params = params.append('categoryBy', articleParams.categoryBy);
      params = params.append('filter', articleParams.filter);
      params = params.append('pageSize', articleParams.pageSize);
      params = params.append('pageIndex', articleParams.pageIndex);
    }

    return this.http.get<any>(this.baseUrl, {params});
  }

  getArticle(id: number) {
    return this.http.get<Article>(this.baseUrl + '/' + id);
  }
}
