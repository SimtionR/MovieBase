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

  
}
