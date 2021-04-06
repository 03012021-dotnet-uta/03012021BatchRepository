import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Person } from '../person';

@Component({
  selector: 'app-persondetails',
  templateUrl: './persondetails.component.html',
  styleUrls: ['./persondetails.component.css']
})
export class PersondetailsComponent implements OnInit {
  @Input() person2?: Person;
  @Output() person3 = new EventEmitter<Person>();//this is an event emitter .. not a Person
  constructor() { }

  ngOnInit(): void {
    //console.log(this.person2.username);
  }

  PassChangedPerson() {
    const form1 = document.querySelector('.changedPerson');
    const inputArr = form1.querySelectorAll('input');
    const p1 = new Person();
    p1.fname = inputArr[0].value;
    p1.lname = inputArr[1].value;
    p1.username = inputArr[2].value;
    p1.password = inputArr[3].value;

    this.person3.emit(p1);


  }
}
