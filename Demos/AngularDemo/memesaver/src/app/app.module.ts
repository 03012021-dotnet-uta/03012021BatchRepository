import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { PersondetailsComponent } from './persondetails/persondetails.component';
import { AppRoutingModule } from './app-routing.module';
import { ListpersonsComponent } from './listpersons/listpersons.component';
import { ListimagesComponent } from './listimages/listimages.component';
import { PersonjustdetailsComponent } from './personjustdetails/personjustdetails.component';
import { MemejustdetailsComponent } from './memejustdetails/memejustdetails.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    PersondetailsComponent,
    ListpersonsComponent,
    ListimagesComponent,
    PersonjustdetailsComponent,
    MemejustdetailsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
