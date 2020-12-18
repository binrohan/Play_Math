import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class MathService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getTrinomial(model: {}): any {
    return this.http.post(this.baseUrl + 'algebra/' + 'trinomial', model);
  }

  getQuadratic(model: {}): any {
    return this.http.post(this.baseUrl + 'algebra/' + 'quadratic', model);
  }

  getMode(model: {}): any {
    return this.http.post(this.baseUrl + 'preAlgebra/' + 'mode', model);
  }
}
