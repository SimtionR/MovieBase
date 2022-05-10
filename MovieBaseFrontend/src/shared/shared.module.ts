import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { KeenSliderComponent } from '../app/keen-slider/keen-slider.component';
import { MovieComponent } from '../app/movie/movie.component';


@NgModule({
  declarations: 
  [
    MovieComponent,
    KeenSliderComponent

  ],
  imports: 
  [
    CommonModule,
    MatIconModule
    
  ],
  exports: 
  [
    CommonModule, 
    MovieComponent,
    KeenSliderComponent,
    MatIconModule 
    
    
  ]
})
export class SharedModule { }
