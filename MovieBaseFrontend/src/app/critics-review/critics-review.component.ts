import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CriticReview, UserReview } from '../services/models';
import {ReviewsService} from '../services/reviews.service';
import {ReactionService} from '../services/reaction.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-critics-review',
  templateUrl: './critics-review.component.html',
  styleUrls: ['./critics-review.component.css']
})
export class CriticsReviewComponent implements OnInit {

  criticReviews: Array<CriticReview> =[];
  movieId:number;
  //blob : string ="https://blobmoviebase.blob.core.windows.net/profilepictures/";

  constructor(private reviewsSerivce: ReviewsService,
              private route: ActivatedRoute,
              private router: Router,
              private reactionService : ReactionService,
              private toastr: ToastrService) { 
    this.route.params.subscribe(result =>{
      this.movieId = result['id'];
      console.log(this.movieId);
    })

    this.reviewsSerivce.getCriticsReview(this.movieId).subscribe(res =>{
      this.criticReviews = res;
      console.log(res);
    })
  }

  ngOnInit(): void {
  }

  getReviewsByMovie(movieId: number){
    this.reviewsSerivce.getCriticsReview(movieId).subscribe(result => {
      this.criticReviews = result;
      console.log(this.criticReviews);
    })
  }

  openProfileDetails(id : number)
  {
    this.router.navigate(['connectionProfile/', id]);
  }

  likeReview(reviewId : number)
  {
    this.reactionService.likeReview(reviewId).subscribe(result => {
      console.log(result);
      this.toastr.success("Reacted to review");
      window.location.replace(window.location.href);
    })
  }

  dislikeReview(reviewId : number){
    this.reactionService.dislikeReview(reviewId).subscribe(result => {
      console.log(result);
      this.toastr.success("Reacted to review");
      window.location.replace(window.location.href);
    })
  }

}
