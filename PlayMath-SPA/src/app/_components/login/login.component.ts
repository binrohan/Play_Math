import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  model: any = {};


  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  login(){
    this.authService.login(this.model).subscribe(
      (next) => {
        console.log('Logged in successfully');
      }, (error) => {
        console.log('Failed to Login');
      }, () => {
        this.router.navigate(['']);
      }
    );
  }

}
