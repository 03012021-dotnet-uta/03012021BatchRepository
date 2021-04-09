import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemejustdetailsComponent } from './memejustdetails.component';

describe('MemejustdetailsComponent', () => {
  let component: MemejustdetailsComponent;
  let fixture: ComponentFixture<MemejustdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MemejustdetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MemejustdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
