import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from './_models/User';
import { AuthService } from './_services/auth.service';
import { UserService } from './_services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'PlayMath-SPA';
  user: User;
  jwtHelper = new JwtHelperService();
  userinfo: any = {};

  constructor(private authService: AuthService, private router: Router, private userService: UserService) {}

  ngOnInit() {
    const token = localStorage.getItem('token');
    this.user = JSON.parse(localStorage.getItem('user'));
    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
    }
    if (this.user) {
      this.authService.currentUser = this.user;
    }
    this.getUser(this.authService.decodedToken.nameid);
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.authService.decodedToken = null;
    this.authService.currentUser = null;
    console.log('Log outed');
    this.router.navigate(['']);
  }

  // loggedIn() {
  //   return this.authService.loggedIn();
  // }

  getUser(id: string){
    this.userService.getUser(id).subscribe((data) => {
      this.userinfo = data;
    }, (error) => console.log('User failed to load'));
  }
}
