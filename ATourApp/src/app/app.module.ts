import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HotelComponent } from './component/hotel/hotel.component';
import { HeaderComponent } from './component/header/header.component';
import { UserAccountComponent } from './component/user-account/user-account.component';
import { BookingInputComponent } from './component/booking-input/booking-input.component';
import { HotelListComponent } from './component/hotel-list/hotel-list.component';
import { ActivatedRoute, RouterModule, Routes } from '@angular/router';
import { CarruselHeaderComponent } from './component/carrusel-header/carrusel-header.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HeaderHotelComponent } from './component/header-hotel/header-hotel.component';
import { FooterComponent } from './component/footer/footer.component';
import { DescriptionComponent } from './component/description/description.component';
import { GaleryComponent } from './component/galery/galery.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './auth/page/login/login.component';
import { RegisterComponent } from './auth/page/register/register.component';
import { ClienteComponent } from './useraccount/cliente/cliente.component';


const routes: Routes = [
  
  {
    path: "hotel/list",
    component: HotelListComponent
  },
  {
    path: 'hotel',
    component: HotelComponent
  },{
    path:'carusel',
    component:CarruselHeaderComponent
  },{
    path:'description',
    component:DescriptionComponent
  },{
    path:'login',
    component:LoginComponent
  },{
    path:'register',
    component:RegisterComponent
  },
  {
    path:"user/detail",
    component:ClienteComponent
  },
  {
    path:'**',
    redirectTo :'hotel'
  }
  
];
@NgModule({
  declarations: [
    AppComponent,
    HotelComponent,
    HeaderComponent,
    UserAccountComponent,
    BookingInputComponent,
    HotelListComponent,
    CarruselHeaderComponent,

    HeaderHotelComponent,
    FooterComponent,
    DescriptionComponent,
    
    GaleryComponent,
    LoginComponent,
    RegisterComponent,
    ClienteComponent,
   
  ],
  imports: [
    FormsModule,
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes),
    NgbModule,
    HttpClientModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [RouterModule]
})
export class AppModule { }
