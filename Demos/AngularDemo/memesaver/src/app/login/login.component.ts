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
  person1?: StringPerson;
  username: string;
  password: string;
  changedPerson: EditPerson;
  stringPerson?: StringPerson;

  constructor(private memeservice: MemesaverService) { }

  ngOnInit(): void {
  }

  login() {
    // const form1 = document.querySelector('.loginform1');
    // const inputArr = form1.querySelectorAll('input');

    // const p1: Person = new Person();
    // p1.fname = inputArr[0].value;
    // p1.lname = inputArr[1].value;
    // p1.username = inputArr[2].value;
    // p1.password = inputArr[3].value;

    // this.person1 = p1;
    //console.log(this.person1);
    this.memeservice.login(this.username, this.password)
      .subscribe
      (
        person => this.stringPerson = person,// "next"
        err => console.log(err),//"error" - for errors - optional
        () => console.log('The subscribe was completed.') //"continue" for cleanup, etc...- optional
      );

  }

  ChangedPerson(person: EditPerson) {
    this.changedPerson = person;
    this.memeservice.EditPerson(person).subscribe(p => console.log(`The post method returned "${p}"`));
  }

}
