import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Answer } from '../_models/Answer';

@Injectable({
  providedIn: 'root'
})
export class AnswerService {

  baseUrl = environment.apiUrl + 'answer';

  constructor(private http: HttpClient) {}

  addAnswer(question: {}) {
    return this.http.post (this.baseUrl, question);
  }

  getAnswers(questionParams, id: number) {
    let params = new HttpParams();

    if (questionParams != null) {
      params = params.append('pageSize', questionParams.pageSize);
      params = params.append('pageIndex', questionParams.pageIndex);
    }

    return this.http.get<any>(this.baseUrl + '/' + id, {params});
  }

  updateAnswer(question: {}, id: number){
    return this.http.put<Answer>(this.baseUrl + '/' + id, question);
  }

  markBestAnswer(question: {}, id: number, uid: string){
    return this.http.put<Answer>(this.baseUrl + '/' + 'best/' + id + '/' + uid, question);
  }
}
