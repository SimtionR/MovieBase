import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ActorsService } from '../Actors/actors.service';
import { ProfileService } from '../profile/profile.service';
import { Actor, Movie, Profile } from '../services/models';
import { MovieService } from '../services/movie.service';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.css']
})
export class SearchResultComponent implements OnInit {
  public movieResults : Array<Movie>;
  public actorResults : Array<Actor>;
  public profileResults : Array<Profile>;
  public blob : string = "https://blobmoviebase.blob.core.windows.net/profilepictures/";

  private search : any;

  constructor(private movieService: MovieService,
              private actorService : ActorsService,
              private profileService : ProfileService,
              private activatedRoute : ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
    this.search = this.activatedRoute.snapshot.paramMap.get('search');

    this.completeSearch(this.search);
    
    


  }


  completeSearch(search: string)
  {
    
    this.movieService.getMoviesBySearch(search).subscribe( m => {
      this.movieResults = m;
      console.log(m);
    })

    this.actorService.getActorsBySearch(search).subscribe( a => {
      this.actorResults = a;
      console.log(a);
    })

    this.profileService.getProfilesBySearch(search).subscribe( p => {
      this.profileResults = p;
     
      console.log(p);
      
    })

   
  }

  openMovieDetails(id : number)
  {
    this.router.navigate(['movieDetails/', id]);
  }

  openActorDetails(id : number)
  {
    console.log("actor details soon to be implemented");
    //this.router.navigate(['movieDetails/', id]);
  }

  openProfileDetails(id : number)
  {
    this.router.navigate(['connectionProfile/', id]);
  }

  


}
