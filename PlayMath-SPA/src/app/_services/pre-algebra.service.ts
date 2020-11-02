import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Mode } from '../_models/_math.models/mode';

@Injectable({
  providedIn: 'root',
})
export class PreAlgebraService {
  baseUrl = environment.apiurl + 'preAlgebra/';

  constructor(private http: HttpClient) {}

  getMode(mode: Mode): any {
    return this.http.post(this.baseUrl + 'mode', mode);
  }
}
