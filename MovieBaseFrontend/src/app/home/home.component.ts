import { Component, OnInit } from '@angular/core';
import { Movie } from '../services/models';
import { MovieService } from '../services/movie.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public sort: string;
  public movies: Array<Movie>;

  constructor(
    private movieService: MovieService,
    private router: Router) { }

  ngOnInit(): void {
    this.movieService.getMovies().subscribe( m =>
     {
       this.movies = m;
       console.log(m);

     })
    
  }

  openMovieDetails(id: number)
  {
    this.router.navigate(['movieDetails/', id]);
  }

  
  
  

}
