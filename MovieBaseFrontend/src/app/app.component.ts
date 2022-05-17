import { Component, OnInit, ViewChild } from '@angular/core';
import {MatSidenav} from '@angular/material/sidenav';
import {BreakpointObserver} from '@angular/cdk/layout';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ProfileService } from './profile/profile.service';
import { Profile } from './services/models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;
  profile: Profile;

  constructor(private observer: BreakpointObserver,
              private router: Router,
              private profileService: ProfileService ){

  }

  ngOnInit(): void {
    this.profileService.getProfileByUserId().subscribe( p =>{
      this.profile = p;
      console.log(p);
    })
  }

  ngAfterViewInit(){
    // this.observer.observe(['(max-width: 800px)']).subscribe((res) => {
    //   if(res.matches){
    //     this.sidenav.mode='over';
    //     this.sidenav.close();
    //   } else {
    //     this.sidenav.mode='side';
    //     this.sidenav.open()
    //   }
    // });
  }

  onSubmit(form: NgForm){
    this.router.navigate(['search',form.value.search])
  }

  openProfile()
  {
    this.router.navigate(['/profile']);
  }

  openHome()
  {
    this.router.navigate(['/']);
  }
  
}
