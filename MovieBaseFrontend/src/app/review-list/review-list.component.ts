import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserReview } from '../services/models';
import {ReviewsService} from '../services/reviews.service';

@Component({
  selector: 'app-review-list',
  templateUrl: './review-list.component.html',
  styleUrls: ['./review-list.component.css']
})
export class ReviewListComponent implements OnInit {
  
  userReviews: Array<UserReview> =[];
  movieId:number;
  blob : string ="https://blobmoviebase.blob.core.windows.net/profilepictures/";

  constructor(private reviewsSerivce: ReviewsService,
              private route: ActivatedRoute,
              private router: Router) { 
    this.route.params.subscribe(result =>{
      this.movieId = result['id'];
      console.log(this.movieId);
    })

    this.reviewsSerivce.getReviewsByMovieId(this.movieId).subscribe(res =>{
      this.userReviews = res;
      console.log(res);
    })
  }

  ngOnInit(): void {
  }

  getReviewsByMovie(movieId: number){
    this.reviewsSerivce.getReviewsByMovieId(movieId).subscribe(result => {
      this.userReviews = result;
      console.log(this.userReviews);
    })
  }

  openProfileDetails(id : number)
  {
    this.router.navigate(['connectionProfile/', id]);
  }


}
