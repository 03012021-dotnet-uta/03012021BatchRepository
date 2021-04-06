import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Person } from '../person';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  person1?: Person;
  username: string;
  password: string;
  changedPerson: Person;
  constructor() { }

  ngOnInit(): void {
  }

  login() {
    const form1 = document.querySelector('.loginform1');
    const inputArr = form1.querySelectorAll('input');

    const p1: Person = new Person();
    p1.fname = inputArr[0].value;
    p1.lname = inputArr[1].value;
    p1.username = inputArr[2].value;
    p1.password = inputArr[3].value;

    this.person1 = p1;
    //console.log(this.person1);
  }

  ChangedPerson(person: Person) {
    this.changedPerson = person;
  }

}
