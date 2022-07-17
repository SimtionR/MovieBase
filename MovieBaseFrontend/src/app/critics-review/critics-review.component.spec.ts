import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriticsReviewComponent } from './critics-review.component';

describe('CriticsReviewComponent', () => {
  let component: CriticsReviewComponent;
  let fixture: ComponentFixture<CriticsReviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CriticsReviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CriticsReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
