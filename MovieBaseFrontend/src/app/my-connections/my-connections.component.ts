import { Component, OnInit } from '@angular/core';
import { Connection, ConnectionPending, Profile, ResponsePending, ResponsePendingRequest } from '../services/models';
import {ConnectionService} from '../services/connection.service';
import { ActivatedRoute, Router } from '@angular/router';
import {ProfileService} from '../profile/profile.service';
import {ToastrService} from 'ngx-toastr';


@Component({
  selector: 'app-my-connections',
  templateUrl: './my-connections.component.html',
  styleUrls: ['./my-connections.component.css']
})
export class MyConnectionsComponent implements OnInit {

  public testArray: number[] = [1,2,3,4,5,6,7,8,1,1,1,1,1,1];
  public connections: Array<Connection>;
  public responsePendings : Array<ResponsePending>;
  public connectionPendings: Array<ConnectionPending>;
  public profileId: any;
  public profile: Profile;
  public blob : string ="https://blobmoviebase.blob.core.windows.net/profilepictures/";
  public acceptedRequest : string = "You accepted a request from ";
  public declinedRequest : string = "You declined a request from ";

  constructor(private connectionServices : ConnectionService,
              private activatedRoute: ActivatedRoute,
              private profileService: ProfileService,
              private toastr: ToastrService,
              private router: Router) {
    
   }

  ngOnInit(): void {
    this.profileId = this.activatedRoute.snapshot.paramMap.get('id');  
    this.connectionServices.getConnectionsByProfile(this.profileId).subscribe( c => {
      this.connections = c;
      console.log(this.connections);

    })

    this.connectionServices.getConnectionsPendingByProfile(this.profileId).subscribe( c => {
      this.connectionPendings = c;
      console.log(this.connectionPendings);
     
    })
    
    this.connectionServices.getResponsePendingsByProfileId(this.profileId).subscribe( c => {
      this.responsePendings = c;
      console.log(this.responsePendings);
      
    })

    this.profileService.getProfileByProfileId(this.profileId).subscribe( p => {
      this.profile = p;
    })
  }

  acceptRequest(pendingId: any, senderId: any, senderName :any, senderPhoto: any)
  {
    
    
    const request: ResponsePendingRequest ={
      pendingId : pendingId,
      senderId : senderId,
      senderName : senderName,
      senderPhoto : senderPhoto,
      receiverId : this.profile.id,
      receiverName : this.profile.userName,
      receiverPhoto : this.profile.profilePicture

    };
    this.connectionServices.acceptConnectionPending(request).subscribe( p =>
      {
        console.log(p);
      });
    this.toastr.success(`${senderName} is now one of you connections!`);
    window.location.replace(window.location.href);
    
    
    

  }

  declineRequest(pendingId: any, senderId: any, senderName :any, senderPhoto: any)
  {
    const request: ResponsePendingRequest ={
      pendingId : pendingId,
      senderId : senderId,
      senderName : senderName,
      senderPhoto : senderPhoto,
      receiverId : this.profile.id,
      receiverName : this.profile.userName,
      receiverPhoto : this.profile.profilePicture

    };
    this.connectionServices.declineConnectionPending(request).subscribe( p => {
      console.log(p);
    });
    this.toastr.success(`You rejected the connetion from ${senderName}`);
    window.location.replace(window.location.href);
  }

  deleteConnection(connectionId : number)
  {
    this.connectionServices.deleteConnectionById(connectionId).subscribe( c =>{     
        console.log("merge ba");
        this.toastr.success("Connection deleted");
        
    });
    window.location.replace(window.location.href);

    
  }

  openProfile(profileId: any)
  {
    this.router.navigate([`connectionProfile/${profileId}`])
  }

    
}
