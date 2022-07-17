import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Reaction } from './models';

@Injectable({
  providedIn: 'root'
})
export class ReactionService {

  private reactionPath = environment.apiUrl +'Reaction/'
  constructor(private http : HttpClient) { }

  getLikesByReview(reviewId : number) : Observable<Array<Reaction>>{
    return this.http.get<Array<Reaction>>(this.reactionPath + `likes/${reviewId}`);
  }

  getDislikesByReview(reviewId: number) : Observable<Array<Reaction>>{
    return this.http.get<Array<Reaction>>(this.reactionPath + `dislikes/${reviewId}`);
  }

  likeReview(reviewId: number) : Observable<Reaction>{
    return  this.http.post<Reaction>(this.reactionPath + `likeReview/${reviewId}`, reviewId);
  }

  dislikeReview(reviewId : number) : Observable<Reaction>{
    return this.http.post<Reaction>(this.reactionPath + `dislikeReview/${reviewId}`, reviewId);
  }

 

  
}
