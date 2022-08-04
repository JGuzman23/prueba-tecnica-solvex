import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarruselHeaderComponent } from './carrusel-header.component';

describe('CarruselHeaderComponent', () => {
  let component: CarruselHeaderComponent;
  let fixture: ComponentFixture<CarruselHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarruselHeaderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarruselHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
