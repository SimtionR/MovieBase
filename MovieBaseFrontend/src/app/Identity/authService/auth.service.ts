import { Injectable } from '@angular/core';
import {environment} from '../../../environments/environment'
import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loginPath = environment.apiUrl+ 'identity/login';
  private registerPath = environment.apiUrl + 'identity/register';
  private adminLoginPath= environment.apiUrl + 'identity/adminLogin';
  private criticLoginPath = environment.apiUrl + 'identity/criticLogin';

  constructor(private http: HttpClient) { }

  login(data: any) : Observable<any>{
    return this.http.post(this.loginPath, data);
  }
  loginAdmin(data : any) : Observable<any>{
    return this.http.post(this.adminLoginPath, data);
  }
  loginCritic(data : any) : Observable<any>{
    return this.http.post(this.criticLoginPath, data);
  }

  register(data: any) : Observable<any>{
    return this.http.post(this.registerPath, data);
  }

  saveToken(token: string){
    localStorage.setItem('token', token);
  }

  getToken()
  {
    return localStorage.getItem('token');
  }

  isLogged()
  {
    if(this.getToken())
      return true;

    return false;
  }
}
