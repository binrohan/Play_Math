import { Routes } from '@angular/router';
import { TrinomialComponent } from './pages/algebra/factor/trinomial/trinomial.component';
import { QuadraticComponent } from './pages/algebra/quadratic/quadratic.component';
import { HomeComponent } from './pages/home/home.component';
import { LandingComponent } from './pages/landing/landing.component';

export const appRoutes: Routes = [
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [],  // Here goes authguard
        children: [
            { path: '', component: LandingComponent},
            { path: 'home', component: HomeComponent },
            { path: 'trinomial', component: TrinomialComponent},
            { path: 'quadratic', component: QuadraticComponent}
        ]
    }
];
