import { Component, OnInit } from '@angular/core';
import { Cliente, Initialize } from '../../model/Cliente.interface';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

   model : Cliente = Initialize.User;

   
  constructor(public authService: AuthService, private router:Router) { }
 

  ngOnInit(): void {
  }

  Create(){
    this.authService.createUser(this.model).subscribe(data => {

      this.router.navigateByUrl('/login');
    }, error => {
      console.log(error);

    })
  }

}
