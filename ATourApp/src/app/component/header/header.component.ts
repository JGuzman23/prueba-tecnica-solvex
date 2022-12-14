import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(public authSeervice:AuthService, private router:Router)  { }


  ngOnInit(): void {
  }
  logout(){
    this.authSeervice.logout();
    this.router.navigateByUrl('login')

  }
  

}
