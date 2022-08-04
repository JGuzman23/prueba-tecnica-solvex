import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from 'src/app/auth/model/Cliente.interface';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

   private apiUrl :string = environment.apiUrl;
  

  constructor(private http:HttpClient) { }

  getCliente(id: number): Observable<Cliente> {

    const url = `${this.apiUrl}/Cliente/by/${id}`
    return this.http.get<Cliente>(url);
  }
 
  updateUser(cliente :Cliente):Observable<any>{
    return this.http.put(`${this.apiUrl}/Cliente`,cliente);
  }
}
