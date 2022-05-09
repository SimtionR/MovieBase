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
        console.log(p);
      })
  }
   


}
