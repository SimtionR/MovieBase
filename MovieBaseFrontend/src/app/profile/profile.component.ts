import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Profile } from '../services/models';
import { ProfileService } from './profile.service';




@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
 
  profile: Profile;


  constructor(private router: Router,
              private profileSerice: ProfileService){

  }
 

  ngOnInit(): void {
    this.profileSerice.getProfileByUserId().subscribe(p =>
      {
        this.profile = p;
        
      })
  }

  
   
  openMovieDetails(id: number)
  {
    this.router.navigate(['movieDetails/', id]);
  }

  removeFromWatchList(movieId: number)
  {
    
    this.profileSerice.removeMovieFromWatchList(movieId).subscribe(p =>
      {
        if(p == true)
        {
          console.log("works");
          
        }
        console.log("did not work");
      })
      console.log('aaaaa');
      this.ngOnInit();
  }

  removeFromPlayList(movieId:number)
  {
    this.profileSerice.removeFromPlayList(movieId).subscribe(p =>
      {
        if(p ===true)
        {
          console.log("works");
         
        }
        console.log("did not work");
      })
     
  }


}
