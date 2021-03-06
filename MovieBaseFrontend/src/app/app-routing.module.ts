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
import {CreateReviewComponent} from './create-review/create-review.component';
import { ChatComponent } from './chat/chat.component';
import {SearchResultComponent} from './search-result/search-result.component';
import { ConnectionProfileComponent } from './connection-profile/connection-profile.component';
import {MyConnectionsComponent} from './my-connections/my-connections.component';
import { AdminloginComponent } from './Identity/adminlogin/adminlogin.component';
import { CriticloginComponent } from './Identity/criticlogin/criticlogin.component';
import { CreateCriticReviewComponent } from './create-critic-review/create-critic-review.component';
import { CriticsReviewComponent } from './critics-review/critics-review.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  //{path: 'search/:show-search', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'admin-login', component: AdminloginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'actors', component: ActorsComponent },
  {path: 'movieDetails/:id', component: MovieDetailsComponent},
  {path :'profile', component: ProfileComponent, canActivate: [AuthGuardService]},
  {path: 'movies', component: MovieComponent},
  {path: 'test', component:KeenSliderComponent},
  {path: 'createReview/:id', component:CreateReviewComponent},
  {path: 'chat', component: ChatComponent},
  {path: 'search/:search', component: SearchResultComponent},
  {path: 'connectionProfile/:id', component: ConnectionProfileComponent},
  {path: 'myConnections/:id', component: MyConnectionsComponent},
  {path: 'critic-login', component: CriticloginComponent},
  {path: 'create-critic-review/:id', component: CreateCriticReviewComponent},
  {path :'critics-review/:id', component: CriticsReviewComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
