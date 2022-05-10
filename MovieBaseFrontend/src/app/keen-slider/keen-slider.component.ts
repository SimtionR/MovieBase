import { Component, ElementRef, Input, ViewChild } from "@angular/core"
import KeenSlider, { KeenSliderInstance } from "keen-slider"


@Component({
  selector: 'app-keen-slider',
  templateUrl: './keen-slider.component.html',
  styleUrls: ['./keen-slider.component.css']
})
export class KeenSliderComponent {
  @Input() slides :{text: string, color: string}[]
  @ViewChild("sliderRef") sliderRef: ElementRef<HTMLElement>

  slider: KeenSliderInstance;
  
  ngAfterViewInit(){
    this.slider = new KeenSlider(this.sliderRef.nativeElement)
  }

  // ngAfterViewInit() {
  //   this.slider = new KeenSlider(this.sliderRef.nativeElement, {
  //     breakpoints: {
  //       "(min-width: 400px)": {
  //         slides: { perView: 2, spacing: 5 },
  //       },
  //       "(min-width: 1000px)": {
  //         slides: { perView: 3, spacing: 10 },
  //       },
  //     },
  //     slides: { perView: 1 },
  //   })
  // }

  // ngAfterViewInit() {
  //   this.slider = new KeenSlider(this.sliderRef.nativeElement, {
  //     breakpoints: {
  //       "(min-width: 400px)": {
  //         slides: { perView: 2, spacing: 5 },
  //       },
  //       "(min-width: 1000px)": {
  //         slides: { perView: 3, spacing: 10 },
  //       },
  //     },
  //     slides: { perView: 1 },
  //   })
  // }

  ngOnDestroy() {
    if (this.slider) this.slider.destroy()
  }
}

