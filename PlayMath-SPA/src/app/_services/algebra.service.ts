import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Quadratic } from '../_models/_math.models/quadratic';
import { Trinomial } from '../_models/_math.models/trinomial';

@Injectable({
  providedIn: 'root',
})
export class AlgebraService {
  baseUrl = environment.apiurl + 'algebra/';

  constructor(private http: HttpClient) {}

  getTrinomial(trinomial: Trinomial): any {
    return this.http.post(this.baseUrl + 'trinomial', trinomial);
  }

  getQuadratic(quadratic: Quadratic): any {
    return this.http.post(this.baseUrl + 'quadratic', quadratic);
  }
}
