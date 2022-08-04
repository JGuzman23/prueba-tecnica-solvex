import { Component, OnInit } from '@angular/core';
import { Cliente, Initialize } from 'src/app/auth/model/Cliente.interface';
import { ClienteService } from '../service/cliente.service';
import { HotelService } from '../../hotel/Service/hotel.service';
import { InitializeR, Reserva } from '../../reserva/model/reserva.interface';
import { AuthService } from 'src/app/auth/services/auth.service';



@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {

  model :Cliente = Initialize.User;
  reservas : Reserva[] =[]; 
  desableEdit:boolean = true;
  constructor( private clienteService: ClienteService,
     private hotelService:HotelService,
     private authService: AuthService) {
      this.clienteService.getCliente(this.authService.id).subscribe(data=>{

        console.log(data);
        this.model=data;
      })
  
      this.hotelService.getReservaByCliente(this.authService.id).subscribe(data=>{
        console.log(data);
        this.reservas=data;
      })
      }

  ngOnInit(): void {
   
  }

 
  guardar(){
    this.clienteService.updateUser(this.model).subscribe(data=>{
    });
  }

  editar(){
    this.desableEdit=false


  }

}
