import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../auth/services/auth.service';

@Component({
  selector: 'app-header-hotel',
  templateUrl: './header-hotel.component.html',
  styleUrls: ['./header-hotel.component.css']
})
export class HeaderHotelComponent implements OnInit {

  constructor(public authSeervice:AuthService, private router:Router) { }

  ngOnInit(): void {
  }
  logout(){
    this.authSeervice.logout();
    this.router.navigateByUrl('login')

  }

}
