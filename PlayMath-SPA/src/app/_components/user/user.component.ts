import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss'],
})
export class UserComponent implements OnInit {
  userId: string;
  user: any = {};
  allRoles = ['Admin', 'Writer', 'Reader'];
  roles: any[] = [];
  userRoles: any[];
  isRoleChanged = false;

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.userId = this.route.snapshot.paramMap.get('id');
    this.getUser(this.userId);
  }

  getUser(id: string) {
    this.userService.getUser(id).subscribe(
      (data) => {
        this.user = data;
        if (this.user.roles) {
          console.log('Here');
          this.roles = this.user.roles;
        }
        console.log(this.roles);
        console.log(this.user);
      },
      (error) => console.log('User failed to load')
    );
  }

  update() {
    this.isRoleChanged = false;
    const newRoleSet = { roleNames: this.roles };
    this.userService.updateUserRole(this.user.id, newRoleSet).subscribe(
      () => {
        this.getUser(this.route.snapshot.paramMap.get('id'));
        alert('User Role Updated');
      },
      (err) => {}
    );
  }

  onSelect(e, value) {
    this.isRoleChanged = true;
    console.log(value.value);
    if (e.target.checked) {
      if (!this.roles.includes(value.value)) {
        this.roles.push(value.value);
      }
    } else if (!e.target.checked) {
      const index = this.roles.indexOf(value.value);
      this.roles.splice(index, 1);
    }
  }

  deleteUser(){
    if(!confirm('Are You Sure?')){
      return false;
    }
    this.userService.deleteUser(this.userId, this.userId).subscribe(() => {
      console.log('User Removed');
      this.router.navigate(['/profile']);
    }, (error) => {
      console.log('User Removed Failed');
    });
  }
}
