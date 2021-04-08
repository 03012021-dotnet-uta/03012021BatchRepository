import { Component, OnInit } from '@angular/core';
import { MemesaverService } from '../memesaver.service';
import { StringPerson } from '../string-person';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-personjustdetails',
  templateUrl: './personjustdetails.component.html',
  styleUrls: ['./personjustdetails.component.css']
})
export class PersonjustdetailsComponent implements OnInit {
  person: StringPerson;

  //yoou need to inject the ActivatedRoute service to use it.
  constructor(private memesaverservice: MemesaverService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.GetPersonById(id);
  }

  GetPersonById(id: string) {
    this.memesaverservice.GetPersonById(id).subscribe(res => this.person = res);

  }

}
