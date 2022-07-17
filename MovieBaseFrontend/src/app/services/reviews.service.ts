import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { CriticReview, UserReview } from './models';

@Injectable({
  providedIn: 'root'
})
export class ReviewsService {

  private userReviewsPath = environment.apiUrl+'Review/';

  constructor(private http: HttpClient) { }

  getReviewById(id : number) : Observable<UserReview>{
    return this.http.get<UserReview>(this.userReviewsPath + `getUserReview/${id}`);
  }

  getReviewsByMovieId(movieId : number) : Observable<Array<UserReview>>
  {
    return this.http.get<Array<UserReview>>(this.userReviewsPath +`reviews/${movieId}`);
  }
  postReview(data : any, movieId : number) : Observable<UserReview>
  {
    return this.http.post<UserReview>(this.userReviewsPath+'createUserReview/'+ movieId,data);
  }
  postCriticReview(data : any, movieId : number) : Observable<CriticReview>{
    return this.http.post<CriticReview>(this.userReviewsPath+`createCriticReview/${movieId}`, data);
  }
  getCriticsReview(movieId: number) : Observable<Array<CriticReview>>
  {
    return this.http.get<Array<CriticReview>>(this.userReviewsPath + `criticReviews/${movieId}`);
  }
    deleteReview(reviewId : number)  : Observable<boolean>{
     return this.http.delete<boolean>(this.userReviewsPath + `deleteReview/${reviewId}`);
  }
}
