import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {ReviewsService} from '../services/reviews.service'
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-critic-review',
  templateUrl: './create-critic-review.component.html',
  styleUrls: ['./create-critic-review.component.css']
})
export class CreateCriticReviewComponent implements OnInit {

  reviewForm: FormGroup
  ratingControl: any;
  movieId: number;

  constructor(private fb:FormBuilder,
              private reviewsService:ReviewsService,
              private route: ActivatedRoute, 
              private router: Router,
              private toastrService: ToastrService) { 

                this.route.params.subscribe(result =>{
                  this.movieId = result['id'];
                  console.log(this.movieId);
                })

                
                this.reviewForm = this.fb.group({
                  "Title":['',Validators.nullValidator],
                  "RewiewContent":['',Validators.nullValidator],
                  "CompanyName":['', Validators.nullValidator],
                  "Rating":['',Validators.nullValidator],
                   
                },
                
                );
              
               
              }

  ngOnInit(): void {
  }


  create(){
    this.reviewsService.postCriticReview(this.reviewForm.value, this.movieId).subscribe(res =>{
        this.toastrService.success("Review posted!");
        this.redirect()
       
    })
  }

  redirect()
  {
    this.router.navigate(["movieDetails", this.movieId])
  }

}
