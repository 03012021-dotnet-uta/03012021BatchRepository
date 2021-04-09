import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EditPerson } from './edit-person';
import { Meme } from './meme';
import { StringPerson } from './string-person';

@Injectable({
  providedIn: 'root'
})

export class MemesaverService {


  //querystrings go here. and anythign else the serviec woud need to function
  // queryString: string = 'https://memesaver.azurewebsites.net/api/meme/';
  queryString: string = 'https://localhost:5001/api/meme/';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };


  constructor(private http: HttpClient) { }


  //here will go the methods you need to provide the service.

  //this is where Obsdervables come in.
  login(username: string, password: string): Observable<StringPerson> {
    return this.http.get<StringPerson>(`${this.queryString}login/${username}/${password}`);
  }

  EditPerson(editPerson: EditPerson): Observable<boolean> {
    console.log('here in service ');
    return this.http.post<boolean>(`${this.queryString}editprofile`, editPerson, this.httpOptions);
  }

  GetAllPersons(): Observable<StringPerson[]> {
    return this.http.get<StringPerson[]>(`${this.queryString}allpersons`);
  }

  GetPersonById(id: string): Observable<StringPerson> {
    return this.http.get<StringPerson>(`${this.queryString}getpersonbyid/${id}`);
  }

  GetAllMemes(): Observable<Meme[]> {
    return this.http.get<Meme[]>(`${this.queryString}memes`);
  }

  GetMemeById(id: string): Observable<Meme> {
    return this.http.get<Meme>(`${this.queryString}getmemebyid/${id}`);
  }

}//end of class
