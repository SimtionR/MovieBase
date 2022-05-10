import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Identity/login/login.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { RegisterComponent } from './Identity/register/register.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GaugeModule } from 'angular-gauge';
import {MatTabsModule} from '@angular/material/tabs';
import {MatIconModule} from '@angular/material/icon';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import { SearchBarComponent } from './search-bar/search-bar/search-bar.component';
import { HomeComponent } from './home/home.component';
import { ActorsComponent } from './Actors/actors/actors.component';
import { MovieDetailsComponent } from './movie-details/movie-details.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatButtonModule} from '@angular/material/button';
import {MatDividerModule} from '@angular/material/divider';
import { AuthService } from './Identity/authService/auth.service';
import {AuthGuardService} from './Identity/auth-guard.service';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { SharedModule } from '../shared/shared.module';
import { ProfileComponent } from './profile/profile.component'
import { IvyCarouselModule } from 'angular-responsive-carousel';
import { NgImageSliderModule } from 'ng-image-slider';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    SearchBarComponent,
    HomeComponent,
    ActorsComponent,
    MovieDetailsComponent,
    ProfileComponent,
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    FormsModule,
    GaugeModule.forRoot(),
    MatFormFieldModule,
    MatTabsModule,
    MatSelectModule,
    MatToolbarModule,
    MatSidenavModule,
    MatButtonModule,
    MatDividerModule,
    SharedModule,
    NgImageSliderModule,
    IvyCarouselModule
  ],
  providers: [
    AuthService, 
    AuthGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
