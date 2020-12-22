import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../_services/auth.service';


@Injectable()
export class AuthGuard implements CanActivate{
    constructor(private router: Router, private authService: AuthService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        const roles = route.firstChild.data.roles as Array<string>;
        if (roles) {
            const match = this.authService.roleMatch(roles);
            if (match) {
                return true;
            } else {
                this.router.navigate(['home']);
                console.log('You are not authorized to access this area');
            }
        }


        if (this.authService.loggedIn()) {
            // logged in so return true
            return true;
        }
        console.log('You shall not pass');
        // not logged in so redirect to login page with the return url
        this.router.navigate([''], { queryParams: { returnUrl: state.url }});
        return false;
    }
}
