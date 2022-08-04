import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderHotelComponent } from './header-hotel.component';

describe('HeaderHotelComponent', () => {
  let component: HeaderHotelComponent;
  let fixture: ComponentFixture<HeaderHotelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeaderHotelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderHotelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
