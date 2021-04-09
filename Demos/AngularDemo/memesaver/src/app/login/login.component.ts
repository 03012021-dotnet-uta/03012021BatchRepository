import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { EditPerson } from '../edit-person';
import { MemesaverService } from '../memesaver.service';
import { Person } from '../person';
import { StringPerson } from '../string-person';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  myBool: boolean = true;
  person1?: StringPerson;
  username: string;
  password: string;
  changedPerson: EditPerson;
  stringPerson?: StringPerson;

  constructor(private memeservice: MemesaverService) { }

  ngOnInit(): void {
  }

  login() {
    this.memeservice.login(this.username, this.password)
      .subscribe
      (
        person => this.stringPerson = person,// "next"
        err => console.log(err),//"error" - for errors - optional
        () => console.log('The subscribe was completed.') //"continue" for cleanup, etc...- optional
      );
  }

  ChangedPerson(person: EditPerson): void {
    this.changedPerson = person;
    this.memeservice.EditPerson(person).subscribe(p => {
      console.log(`The post method returned "${p}"`);
      this.myBool = p;
    });
  }

}
