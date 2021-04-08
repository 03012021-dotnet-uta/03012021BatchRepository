import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListimagesComponent } from './listimages/listimages.component';
import { ListpersonsComponent } from './listpersons/listpersons.component';
import { LoginComponent } from './login/login.component';
import { PersonjustdetailsComponent } from './personjustdetails/personjustdetails.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'listpersons', component: ListpersonsComponent },
  { path: 'personjustdetails/:id', component: PersonjustdetailsComponent },
  { path: 'listimages', component: ListimagesComponent },
  { path: '**', component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }