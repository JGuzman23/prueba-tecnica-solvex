import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {   BehaviorSubject, map, Observable, throwError } from 'rxjs';
import { AuthResponse } from '../model/auth.interface';
import { Cliente } from '../model/Cliente.interface';
import {  catchError } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';


const helper = new JwtHelperService();
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public token :string | undefined;
  private loggedIn :boolean = false;
  public id :number =0;

  
  
  constructor(private http:HttpClient) { 
    this.token = localStorage.getItem('token')?? '';
    if(this.token !== ''){
      this.loggedIn = !this.loggedIn;
      this.id = JSON.parse(localStorage.getItem('idUser')?? '');
      this.checktoken();
    }
  }
   get isLogged():boolean{
    return this.loggedIn;}
  


  private apiUrl :string = environment.apiUrl;

  login(cliente :Cliente):Observable<AuthResponse| void> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/Auth`,cliente)
    .pipe(
      map((data:AuthResponse)=>{
        this.saveToken(data.token, data.id);
        this.token = data.token;
        this.id = data.id;
        this.loggedIn=true;
        console.log(data);
        
        return data;

    }),catchError((error)=>this.handlerError(error)));
  }
  createUser(cliente :Cliente):Observable<any>{
    return this.http.post(`${this.apiUrl}/Cliente`,cliente);
  }
  logout(){
    localStorage.removeItem('token');
    this.loggedIn= false;

  }

  private checktoken():void{
    const isExpired = helper.isTokenExpired(this.token);
    if(isExpired){
      this.logout();
    }else{ 
      this.loggedIn= true;

    }
  }

  private handlerError(error:any):Observable<never>{
    let errorMensaje = `Ha ocurrido un error:${error.message}`;
    window.alert(errorMensaje);
    return throwError(errorMensaje)
  }
  private saveToken(token:string, id:number){
    localStorage.setItem('token',token)
    localStorage.setItem('idUser',id.toString())
  }

}
