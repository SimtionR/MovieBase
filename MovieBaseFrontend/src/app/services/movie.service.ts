import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Movie, MovieDetails } from './models';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  private moviePath= environment.apiUrl+'movie/'
  private movieDetailsPath = environment.apiUrl +'MovieDetails/'

  constructor(private http: HttpClient) { }

  // getMovies(
  //   ordering: string,
  //   search?: string
  // ): Observable<Movie>{
  //   let params = new HttpParams().set('ordering',ordering);

  //   if(search){
  //     params= new HttpParams().set('ordering',ordering).set('search',search);
  //   }

  //   return this.http.get<Movie>(this.moviePath, {
  //     params:params,
  //   });
  // }

  getMovies() : Observable<Array<Movie>>
  {
    return this.http.get<Array<Movie>>(this.moviePath + 'movies');
  }

  getMovie(id:number) : Observable<Movie>
  {
    return this.http.get<Movie>(this.moviePath + `movieId/${id}`);
  }

  getMovieDetails(id:number) : Observable<MovieDetails>
  {
    return this.http.get<MovieDetails>(this.movieDetailsPath + `movieDetails/${id}`);
  }

  getMoviesBySearch(search:string) : Observable<Array<Movie>>
  {
    return this.http.get<Array<Movie>>(this.moviePath + `movieSearch/${search}`);
  }
}
