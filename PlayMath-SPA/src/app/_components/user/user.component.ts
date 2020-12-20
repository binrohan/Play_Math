import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {
  userId: string;
  user: any = {};
  allRoles = ['Admin', 'Manager', 'Developer'];
  roles: any[];
  userRoles: any[];

  constructor(private userService: UserService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.userId = (this.route.snapshot.paramMap.get('id'));
    this.getUser(this.userId);
  }

  getUser(id: string) {
    this.userService.getUser(id).subscribe(
      (data) => {
        this.user = data;
        console.log(this.user);
      },
      (error) => console.log('User failed to load')
    );
  }

}
