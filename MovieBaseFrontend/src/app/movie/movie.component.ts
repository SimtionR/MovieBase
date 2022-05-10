import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from '../services/models';
import { MovieService } from '../services/movie.service';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {

  public movies: Array<Movie>;


  constructor(
    private movieService: MovieService,
    private router: Router) { }

    ngOnInit(): void {
      this.movieService.getMovies().subscribe( m =>
       {
         this.movies = m;
         console.log(m);
         console.log("hello from movie cmp");
  
       })
      
    }
  
    openMovieDetails(id: number)
    {
      this.router.navigate(['movieDetails/', id]);
    }
}
