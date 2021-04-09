import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Meme } from '../meme';
import { MemesaverService } from '../memesaver.service';

@Component({
  selector: 'app-memejustdetails',
  templateUrl: './memejustdetails.component.html',
  styleUrls: ['./memejustdetails.component.css']
})
export class MemejustdetailsComponent implements OnInit {
  meme: Meme;

  //you need to inject the ActivatedRoute service to use it.
  constructor(private memesaverservice: MemesaverService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.GetMemeById(id);
  }

  GetMemeById(id: string): void {
    this.memesaverservice.GetMemeById(id).subscribe(res => this.meme = res);

  }
}
