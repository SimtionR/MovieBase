import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {ReviewsService} from '../services/reviews.service'
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-review',
  templateUrl: './create-review.component.html',
  styleUrls: ['./create-review.component.css']
})
export class CreateReviewComponent implements OnInit {

  reviewForm: FormGroup
  ratingControl: any;
  movieId: number;

  constructor(private fb:FormBuilder,
              private reviewsService:ReviewsService,
              private route: ActivatedRoute, 
              private router: Router,
              private toastrService: ToastrService) { 
                this.reviewForm = this.fb.group({
                  "Title":['',Validators.nullValidator],
                  "RewiewContent":['',Validators.nullValidator],
                  "Rating":['',Validators.nullValidator],
                  "MovieId":['']
                });
              
                this.route.params.subscribe(result =>{
                  this.movieId = result['id'];
                  console.log(this.movieId);
                })
              }

  ngOnInit(): void {
  }


  create(){
    this.reviewsService.postReview(this.reviewForm.value).subscribe(res =>{
      console.log(res);
    })

  }

}
