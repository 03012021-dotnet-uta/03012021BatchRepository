import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonjustdetailsComponent } from './personjustdetails.component';

describe('PersonjustdetailsComponent', () => {
  let component: PersonjustdetailsComponent;
  let fixture: ComponentFixture<PersonjustdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonjustdetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonjustdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
