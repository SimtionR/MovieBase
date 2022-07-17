import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateCriticReviewComponent } from './create-critic-review.component';

describe('CreateCriticReviewComponent', () => {
  let component: CreateCriticReviewComponent;
  let fixture: ComponentFixture<CreateCriticReviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateCriticReviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateCriticReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
