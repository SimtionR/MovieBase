import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriticloginComponent } from './criticlogin.component';

describe('CriticloginComponent', () => {
  let component: CriticloginComponent;
  let fixture: ComponentFixture<CriticloginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CriticloginComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CriticloginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
