import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Trinomial } from '../_models/_math.models/trinomial';

@Injectable({
  providedIn: 'root',
})
export class AlgebraService {
  baseUrl = environment.apiurl + 'algebra/';

  constructor(private http: HttpClient) {}

  getMaths(trinomial: Trinomial): any {
    return this.http.post(this.baseUrl + 'trinomial', trinomial);
  }
}
