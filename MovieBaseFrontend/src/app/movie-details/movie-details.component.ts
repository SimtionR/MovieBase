import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProfileService } from '../profile/profile.service';
import { Movie, MovieDetails } from '../services/models';
import { MovieService } from '../services/movie.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  public movieDetails: MovieDetails;
  public movie: Movie;
  public movieId:any;
  public metaScore:number =0;

  constructor(private movieService: MovieService,
              private activatedRoute: ActivatedRoute,
              private profileService: ProfileService,
              private toastrService: ToastrService,
              private router:Router) { }

  ngOnInit(): void {
    this.movieId = this.activatedRoute.snapshot.paramMap.get('id');

    this.movieService.getMovieDetails(this.movieId).subscribe(m =>
      {
        this.movieDetails=m;
        this.metaScore= m.metaScore;
        console.log(this.movieDetails);
      })
     this.movieService.getMovie(this.movieId).subscribe(m =>
      {
        this.movie=m;
        console.log(m);
      }) 
      
  }

  getColor(value:number) :string{
    if(value>75){
      return '#5ee432';
    }else if (value > 50){
      return '#fffa50';
    } else if (value > 30){
      return '#f7aa38';
    } else {
      return '#ef4655';
    } 

  }

  addToWatchList(movieId:any){
    this.profileService.addToWatchList(movieId).subscribe(
      x => {
        if(x === true)
        {
          this.toastrService.success("Added to watchlist");
          console.log("added");
          
        }
        else{
          this.toastrService.error("The movie is already in the watchlist");
          console.log("not added");
        }
        
      }
      
    );
    this.ngOnInit();
  }

  addToPlayList(movieId:any){
    this.profileService.addToPlayList(movieId).subscribe(
      x => {
        if(x === true)
        {
          this.toastrService.success("Added to watchlist");
          console.log("added");
         
        }
        else{
          this.toastrService.error("The movie is already in the playlist");
          console.log("not added");
          
        }
        
      }
    );
    this.ngOnInit();
  }

  seeCriticsReview(movieId: any)
  {
    this.router.navigate([`/critics-review/${movieId}`]);
  }


  navigateToCreateComment(movieId: any)
  {
    this.router.navigate([`/createReview/${movieId}`]);
  }

}
