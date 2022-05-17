import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Profile } from '../services/models';
import { ProfileService } from './profile.service';
import {FormGroup, FormBuilder, FormControl} from '@angular/forms';



@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
 
  profile: Profile;
  selectedPhoto: File;
  profileForm: FormGroup;
  blob : string;


  constructor(private router: Router,
              private profileSerice: ProfileService,
              private toastrService: ToastrService){

  }
 

  ngOnInit(): void {
    this.profileForm = new FormGroup({
      profileImage :new FormControl(null)
    }); 

    this.profileSerice.getProfileByUserId().subscribe(p =>
      {
        this.profile = p;
        this.blob ="https://blobmoviebase.blob.core.windows.net/profilepictures/" + p.profilePicture;
        console.log(this.blob);
        
      })
  }

  onFileChange(e: any) {
  //  console.log(e);
  //  this.selectedPhoto!.file = (<HTMLInputElement>e.target).files![0];
  this.selectedPhoto = <File>e.target.files[0];
  }

  onSubmit()
  {
    const formData = new FormData();
    // formData.append(this.selectedPhoto.name, this.selectedPhoto.file);

    formData.append('Name', this.selectedPhoto.name);
    formData.append('File', this.selectedPhoto);
    this.profileSerice.uploadProfilePicture(formData).subscribe(res =>
      {
        console.log(res);
      });
  }
   
  openMovieDetails(id: number)
  {
    this.router.navigate(['movieDetails/', id]);
  }

  removeFromWatchList(movieId: number)
  {
    
    this.profileSerice.removeMovieFromWatchList(movieId).subscribe(p =>
      {
        this.profileSerice.getProfileByUserId().subscribe(p =>
          {
            this.profile = p;
            
          })
        if(p === true)
        {
          this.toastrService.success("Removed from watchlist");
          console.log("works");
          
        }
        else{
          this.toastrService.error("Could not be removed");
        }
      })
     
  }

  removeFromPlayList(movieId:number)
  {
    this.profileSerice.removeFromPlayList(movieId).subscribe(p =>
      {
        this.profileSerice.getProfileByUserId().subscribe(p =>
          {
            this.profile = p;
            
          })
        if(p ===true)
        {
          this.toastrService.success("Removed from playlist");
         
         
        }
        else{
          this.toastrService.error("Could not be removed");
        }
        
      })
     
  }


}
