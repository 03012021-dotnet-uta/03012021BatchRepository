import { Component, OnInit } from '@angular/core'; import { Meme } from '../meme';
import { MemesaverService } from '../memesaver.service';

@Component({
  selector: 'app-listimages',
  templateUrl: './listimages.component.html',
  styleUrls: ['./listimages.component.css']
})
export class ListimagesComponent implements OnInit {
  memesArray: Meme[];
  constructor(private memesaverservice: MemesaverService) { }

  // all initialization logic goes here in the NgOnInit function
  ngOnInit(): void {
    this.GetAllMemes();
  }

  GetAllMemes(): void {
    this.memesaverservice.GetAllMemes().subscribe(res => this.memesArray = res)
  }
}
