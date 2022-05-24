import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Actor } from '../services/models';

@Injectable({
  providedIn: 'root'
})
export class ActorsService {

  private actorPath = environment.apiUrl +'Actor/';
  //private allActorsPath = environment.apiUrl+ 'Actor/getActors'
  //private actorPath = environment.apiUrl+ 'Actor/acotrId/';
  private testActors = Array<Actor>();

  constructor(private http: HttpClient) { }


  getActors() :Observable<Array<Actor>>{
    return this.http.get<Array<Actor>>(this.actorPath + 'getActors');
  }

  getActor(actorId : number) : Observable<Actor>{
    return this.http.get<Actor>(this.actorPath+ `actorId/${actorId}`);
  }

  getActorsBySearch(search : string) : Observable<Array<Actor>>
  {
    return this.http.get<Array<Actor>>(this.actorPath + `actors/${search}`);
  }

  // getActorsFromMovie(actorsId: Array<number>) : Observable<Array<Actor>>{

  //   var actors: Observable<Array<Actor>>
  //   actorsId.forEach(id=>  =this.testActors.push(this.getActor(id).subscribe);
    
    
  // }
}
