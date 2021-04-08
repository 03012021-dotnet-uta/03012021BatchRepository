import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListpersonsComponent } from './listpersons.component';

describe('ListpersonsComponent', () => {
  let component: ListpersonsComponent;
  let fixture: ComponentFixture<ListpersonsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListpersonsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListpersonsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
