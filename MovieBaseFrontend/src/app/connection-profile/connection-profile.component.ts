import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfileService } from '../profile/profile.service';
import { ConnectionService } from '../services/connection.service';
import { Profile } from '../services/models';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-connection-profile',
  templateUrl: './connection-profile.component.html',
  styleUrls: ['./connection-profile.component.css']
})
export class ConnectionProfileComponent implements OnInit {

  public profile: Profile;
  public profileId: any;
  public blob : string;

  constructor(private profileService: ProfileService,
              private connectionService: ConnectionService,
              private activatedRoute: ActivatedRoute,
              private router: Router,
              private toastr: ToastrService) { }

  ngOnInit(): void {
    this.profileId = this.activatedRoute.snapshot.paramMap.get('id');

    this.profileService.getProfileByProfileId(this.profileId).subscribe( p =>{
      this.profile = p;
      this.blob ="https://blobmoviebase.blob.core.windows.net/profilepictures/" + p.profilePicture;
      console.log(p);
    })
  }

  openMovieDetails(id: number)
  {
    this.router.navigate(['movieDetails/', id]);
  }
  openChat()
  {
    this.router.navigate(['chat']);
  } 

  addConnection(receiverId: number)
  {
    this.connectionService.sendConnectionPending(receiverId).subscribe(c => 
      {
        console.log(c);
      });
    this.toastr.success(`Connection request send to ${this.profile.userName}`);
  }

}
