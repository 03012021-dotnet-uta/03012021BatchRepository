import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EditPerson } from './edit-person';
import { StringPerson } from './string-person';

@Injectable({
  providedIn: 'root'
})

export class MemesaverService {


  //querystrings go here. and anythign else the serviec woud need to function
  queryStringProd: string = 'https://memesaver.azurewebsites.net/api/meme/';
  queryStringDev: string = 'https://localhost:5001/api/meme/';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };


  constructor(private http: HttpClient) { }


  //here will go the methods you need to provide the service.

  //this is where Obsdervables come in.
  login(username: string, password: string): Observable<StringPerson> {
    return this.http.get<StringPerson>(`${this.queryStringProd}login/${username}/${password}`);
  }

  EditPerson(editPerson: EditPerson): Observable<boolean> {
    console.log('here in service ');
    return this.http.post<boolean>(`${this.queryStringDev}editprofile`, editPerson, this.httpOptions);
  }
}
