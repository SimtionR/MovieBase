import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Profile } from '../services/models';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  private profilePath = environment.apiUrl +'profile/';

  constructor(private http:HttpClient) { }



  getProfileByUserId() :Observable<Profile>
  {

    return this.http.get<Profile>(this.profilePath + 'userProfile');
  }

  removeMovieFromWatchList(movieId: number) : Observable<boolean>
  {
    return this.http.patch<boolean>(this.profilePath + `removeFromWatchList/${movieId}`, null);
    
  }

  removeFromPlayList(movieId:number) :Observable<boolean>
  {
    return this.http.patch<boolean>(this.profilePath + `removeFromPlayList/${movieId}`, null);
  }

  addToPlayList(movieId:number) : Observable<boolean>
  {
    return this.http.patch<boolean>(this.profilePath + `addToPlayList/${movieId}`, null);
  }

  addToWatchList(movieId:number) : Observable<boolean>
  {
    return this.http.patch<boolean>(this.profilePath + `addToWatchList/${movieId}`, null);
  }

  uploadProfilePicture(file: FormData) :Observable<any>
  {
    return this.http.post<any>(this.profilePath+'uploadProfile', file);
  }

  
}
