import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cliente, Initialize } from '../../model/Cliente.interface';
import { AuthService } from '../../services/auth.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model : Cliente = Initialize.User;

  constructor(public authService: AuthService,
     private router:Router
    ) { 
      this.authService.isLogged && (
        this.router.navigateByUrl('hotel')
        
      );

      console.log(this.authService.isLogged)
    }

  ngOnInit(): void {
  }

  login(){
    this.authService.login(this.model).subscribe(data => {

      
      this.router.navigateByUrl('/hotel');
    });
  }

  

}
