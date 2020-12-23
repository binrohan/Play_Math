import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class QuizService {
  baseUrl = environment.apiUrl + 'quiz/';

  constructor(private http: HttpClient) {}

  addQuiz(model: {}){
    return this.http.post(this.baseUrl, model);
  }

  requestQuiz(){
    return this.http.get<any>(this.baseUrl);
  }

  getQuiz(id: number){
    return this.http.get(this.baseUrl + 'quiz/' + id);
  }
}
