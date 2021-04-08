import { Component, OnInit } from '@angular/core';
import { MemesaverService } from '../memesaver.service';
import { StringPerson } from '../string-person';

@Component({
  selector: 'app-listpersons',
  templateUrl: './listpersons.component.html',
  styleUrls: ['./listpersons.component.css']
})
export class ListpersonsComponent implements OnInit {
  personsArray: StringPerson[];
  constructor(private memesaverservice: MemesaverService) { }

  // all initialization logic goes here in the NgOnInit function
  ngOnInit(): void {
    this.GetAllPersons();
  }

  GetAllPersons(): void {
    this.memesaverservice.GetAllPersons().subscribe(res => this.personsArray = res)
  }

}//end of class
