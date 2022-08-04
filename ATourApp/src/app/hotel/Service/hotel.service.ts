import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Hotel } from '../Interfaces/hotel.interface';
import { HotObservable } from "rxjs/internal/testing/HotObservable";
import { Reserva } from '../../reserva/model/reserva.interface';
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})

export class HotelService {


    private apiUrl :string = environment.apiUrl;

    constructor(private http: HttpClient) { }

    getAllHotel(): Observable<Hotel[]> {

        const url = `${this.apiUrl}/Hotel`
        return this.http.get<Hotel[]>(url);
    }

    getHotelByName(name: string): Observable<Hotel> {

        const url = `${this.apiUrl}/Hotel/${name}`
        return this.http.get<Hotel>(url);
    }

    getHotelById(id: number): Observable<Hotel> {

        const url = `${this.apiUrl}/Hotel/por/id?id=${id}`
        return this.http.get<Hotel>(url);
    }

    reservar(reserva: Reserva): Observable<any> {
        return this.http.post(`${this.apiUrl}/Reserva/CreateReserva`, reserva);

    }

    getReservaByCliente(id: number): Observable<Reserva[]> {

        const url = `${this.apiUrl}/Reserva/${id}`
        return this.http.get<Reserva[]>(url);
    }



}