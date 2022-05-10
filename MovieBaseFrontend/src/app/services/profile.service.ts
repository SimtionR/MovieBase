import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  profilePath = environment.apiUrl +'profile/';

  constructor(http: HttpClient) { }

  
}
