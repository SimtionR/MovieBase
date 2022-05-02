import { Component, OnInit } from '@angular/core';
import { Actor, Movie } from '../../services/models';
import { ActorsService } from '../actors.service';

@Component({
  selector: 'app-actors',
  templateUrl: './actors.component.html',
  styleUrls: ['./actors.component.css']
})
export class ActorsComponent implements OnInit {

  public actors: Array<Actor>;

  constructor(private actorService: ActorsService) { }

  ngOnInit(): void {
    this.actorService.getActors().subscribe(a =>{
      this.actors = a;
      console.log(a);
    })
  }

}
