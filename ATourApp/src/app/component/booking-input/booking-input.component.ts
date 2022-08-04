import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Hotel } from 'src/app/hotel/Interfaces/hotel.interface';
import { HotelService } from '../../hotel/Service/hotel.service';

@Component({
  selector: 'app-booking-input',
  templateUrl: './booking-input.component.html',
  styleUrls: ['./booking-input.component.css'],

})
export class BookingInputComponent implements OnInit {


  @Output() onEnter:EventEmitter<string> = new EventEmitter();
  hotel:Hotel[]=[];

  constructor( ) { }

  ngOnInit(): void {
  }

  @Input() termino:string='';


  buscar(){
   
    this.onEnter.emit(this.termino);
  }
  

}
