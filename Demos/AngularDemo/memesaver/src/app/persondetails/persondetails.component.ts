import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Guid } from 'guid-typescript';
import { EditPerson } from '../edit-person';
import { Person } from '../person';
import { StringPerson } from '../string-person';

@Component({
  selector: 'app-persondetails',
  templateUrl: './persondetails.component.html',
  styleUrls: ['./persondetails.component.css']
})
export class PersondetailsComponent implements OnInit {
  @Input() person2?: StringPerson;
  @Output() person3 = new EventEmitter<EditPerson>();//this is an event emitter .. not a Person
  constructor() { }

  ngOnInit(): void {
    //console.log(this.person2.username);
  }

  PassChangedPerson() {
    const form1 = document.querySelector('.changedPerson');
    const inputArr = form1.querySelectorAll('input');
    const p1 = new EditPerson();
    p1.fname = inputArr[0].value;
    p1.lname = inputArr[1].value;
    p1.newUsername = inputArr[2].value;
    p1.newPassword = inputArr[3].value;
    p1.personId = inputArr[5].value;
    p1.passwordHash = inputArr[4].value;
    p1.username = inputArr[6].value;

    this.person3.emit(p1);


  }
}
