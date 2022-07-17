import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule,FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../authService/auth.service';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-adminlogin',
  templateUrl: './adminlogin.component.html',
  styleUrls: ['./adminlogin.component.css']
})
export class AdminloginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(private fb: FormBuilder,
    private authService :AuthService,
    private router: Router,
    private toastrService: ToastrService,) 
    {
      this.loginForm = this.fb.group({
        'username':['', [Validators.required]],
        'password':['', [Validators.required]]
      })

    }

  ngOnInit(): void {
    
  }

  login(){
    this.authService.loginAdmin(this.loginForm.value).subscribe(
      data => {//this.authService.saveToken(data.encryptedToken['token']);

      localStorage.setItem('token', data.encryptedToken);
      console.log(data);
      this.toastrService.success("Logged in");
      this.router.navigate(["/"]);
      
    }
    );
  }

  get username()
  {
    return this.loginForm.get('username');
  }

  get password()
  {
    return this.loginForm.get('password');
  }

}
