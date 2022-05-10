import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActorsComponent } from './Actors/actors/actors.component';
import { HomeComponent } from './home/home.component';
import { AuthGuardService } from './Identity/auth-guard.service';
import {LoginComponent} from './Identity/login/login.component';
import { RegisterComponent } from './Identity/register/register.component';
import { KeenSliderComponent } from './keen-slider/keen-slider.component';
import {MovieDetailsComponent} from './movie-details/movie-details.component';
import { MovieComponent } from './movie/movie.component';
import {ProfileComponent} from './profile/profile.component'


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'search/:show-search', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'actors', component: ActorsComponent },
  {path: 'movieDetails/:id', component: MovieDetailsComponent},
  {path :'profile', component: ProfileComponent, canActivate: [AuthGuardService]},
  {path: 'movies', component: MovieComponent},
  {path: 'test', component:KeenSliderComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
