import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getUsers(userParams?) {
    let params = new HttpParams();

    if (userParams != null) {
      params = params.append('filter', userParams.filter);
      params = params.append('pageSize', userParams.pageSize);
      params = params.append('pageIndex', userParams.pageIndex);
    }

    return this.http.get<any>(this.baseUrl + 'user/', { params });
  }
  getUser(id: any) {
    return this.http.get<User>(this.baseUrl + 'user/' + id);
  }

  updateUser(id: string, model: {}) {
    return this.http.put<User>(this.baseUrl + 'user/' + id, model);
  }

  updateUserRole(uId: string, roles: {}){
    return this.http.post(this.baseUrl + 'user/editRoles/' + uId, roles);
  }

  deleteUser(uId: string, aId: string){
    return this.http.delete(this.baseUrl + 'user/' + uId + '/' + aId);
  }
}
