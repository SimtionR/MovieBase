import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { UserReview } from './models';

@Injectable({
  providedIn: 'root'
})
export class ReviewsService {

  private userReviewsPath = environment.apiUrl+'Review/';

  constructor(private http: HttpClient) { }

  getReviewById(id: number) : Observable<UserReview>{
    return this.http.get<UserReview>(this.userReviewsPath + `getUserReview/${id}`);
  }

  getReviewsByMovieId(movieId: number) :Observable<Array<UserReview>>
  {
    return this.http.get<Array<UserReview>>(this.userReviewsPath +`reviews/${movieId}`);
  }
  postReview(data:any) : Observable<any>
  {
    return this.http.post(this.userReviewsPath+'createUserReview',data);
  }
}
