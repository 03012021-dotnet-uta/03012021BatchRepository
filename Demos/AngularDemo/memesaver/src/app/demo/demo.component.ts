import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-demo',
  templateUrl: './demo.component.html',
  styleUrls: ['./demo.component.css']
})
export class DemoComponent implements OnInit {
  myNumber: number = 0;
  myStrings: string;
  constructor() { }

  ngOnInit(): void {
    this.function4();
  }

  function1(): void {
    this.myNumber++;
  }

  function2(s1: string, s2: string): void {
    this.myStrings = s1 + s2;
  }

  function3(myString: string): string {
    return myString + myString;
  }

  function4(): number {
    return 20;
  }

}
