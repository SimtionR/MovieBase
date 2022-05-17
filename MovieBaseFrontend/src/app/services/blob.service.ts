import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BlobService {
  private blobPath = environment.apiUrl +'blob/'

  constructor(private http: HttpClient) { }


  getBlobPicture : Observable
  {
    
  }



}
