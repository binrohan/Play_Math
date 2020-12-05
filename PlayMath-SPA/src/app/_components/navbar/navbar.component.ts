import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(public authService: AuthService, private route: Router) { }

  ngOnInit() {
  }

  logOut() {
    // localStorage.removeItem('token');
    // localStorage.removeItem('user');
    // this.authService.decodedToken = null;
    // this.authService.currentUser = null;
    console.log('logout');
  }

}
