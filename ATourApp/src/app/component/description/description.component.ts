import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Hotel } from 'src/app/hotel/Interfaces/hotel.interface';
import { HotelService } from 'src/app/hotel/Service/hotel.service';
import { InitializeR, Reserva } from '../../reserva/model/reserva.interface';
import { InitializeH } from '../../hotel/Interfaces/hotel.interface';
import { AuthService } from '../../auth/services/auth.service';

@Component({
  selector: 'app-description',
  templateUrl: './description.component.html',
  styleUrls: ['./description.component.css']
})
export class DescriptionComponent implements OnInit {

  model: Reserva = InitializeR.reserva;
  hotel: Hotel = InitializeH.Hotel;
  
  constructor(public hotelService: HotelService,
    public activatedRoute: ActivatedRoute, private authService: AuthService) {

    this.activatedRoute.queryParams.subscribe(params => {
      const id: any = params['id'] || null;

      this.hotelService.getHotelById(id).subscribe(data => {
        this.hotel=data;
      })

    });
  }

  ngOnInit(): void {



  }

  reservar() {
    this.model.clienteId = this.authService.id;
    this.model.hotelId = this.hotel.id;
    this.hotelService.reservar(this.model).subscribe(data => {

    }, error => {
      console.log(error);

    })
  }

}
