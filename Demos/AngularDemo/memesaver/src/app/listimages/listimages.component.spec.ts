import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListimagesComponent } from './listimages.component';

describe('ListimagesComponent', () => {
  let component: ListimagesComponent;
  let fixture: ComponentFixture<ListimagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListimagesComponent],
      imports: [HttpClientTestingModule]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListimagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
