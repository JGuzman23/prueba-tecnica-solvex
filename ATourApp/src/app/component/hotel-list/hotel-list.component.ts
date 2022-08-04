import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Hotel } from '../../hotel/Interfaces/hotel.interface';
import { HotelService } from '../../hotel/Service/hotel.service';
import { AuthService } from '../../auth/services/auth.service';

@Component({
  selector: 'app-hotel-list',
  templateUrl: './hotel-list.component.html',
  styleUrls: ['./hotel-list.component.css']
})
export class HotelListComponent implements OnInit {

  constructor(public hotelService: HotelService, private router:Router, public authService:AuthService) { }

  hoteles!: Hotel[];
  termino: string = '';
  ngOnInit(): void {

    console.log(this.authService.isLogged)
    !this.authService.isLogged && (
      this.router.navigateByUrl('login')
      // console.log("estoy loggeado")
    );

    this.hotelService.getAllHotel().subscribe(data => {

      this.hoteles = data;

    })

  }
  buscar(valor: string) {

    this.hoteles=[];
    this.termino = valor;
    console.log(this.termino);
    this.hotelService.getHotelByName(this.termino).subscribe(data => {
      this.hoteles.push(data);

      console.log(this.hoteles);

    })
  }

  verHotel(id:number){
     this.router.navigate(['/description',id]);
  }


}
