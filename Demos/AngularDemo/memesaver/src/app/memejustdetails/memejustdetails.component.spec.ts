import { HttpClientTestingModule  /*,HttpTestingController*/ } from '@angular/common/http/testing';
import { Type } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MemesaverService } from '../memesaver.service';

import { MemejustdetailsComponent } from './memejustdetails.component';

describe('MemejustdetailsComponent', () => {
  let component: MemejustdetailsComponent;
  let fixture: ComponentFixture<MemejustdetailsComponent>;
  // let httpMock: HttpTestingController;
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MemejustdetailsComponent],
      imports: [HttpClientTestingModule]
    })
      .compileComponents();
    // httpMock = fixture.debugElement.injector.get<HttpTestingController>(HttpTestingController as Type<HttpTestingController>);
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MemejustdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

});
