import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Question } from '../_models/Question';

@Injectable({
  providedIn: 'root',
})
export class QuestionService {
  baseUrl = environment.apiUrl + 'question';

  constructor(private http: HttpClient) {}

  addQuestion(question: {}) {
    return this.http.post (this.baseUrl, question);
  }

  getQuestions(questionParams) {
    let params = new HttpParams();

    if (questionParams != null) {
      params = params.append('categoryBy', questionParams.categoryBy);
      params = params.append('byUserId', questionParams.byUserId);
      params = params.append('filter', questionParams.filter);
      params = params.append('pageSize', questionParams.pageSize);
      params = params.append('pageIndex', questionParams.pageIndex);
    }

    return this.http.get<any>(this.baseUrl, {params});
  }

  getQuestion(id: number) {
    return this.http.get<Question>(this.baseUrl + '/' + id);
  }

  updateQuestion(question: {}, id: number){
    return this.http.put<Question>(this.baseUrl + '/' + id, question);
  }

  viewQuestion(id: number){
    return this.http.put<Question>(this.baseUrl + '/view/' + id, {});
  }
}
