import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DemoComponent } from './demo.component';

describe('DemoComponent', () => {
  let component: DemoComponent;
  let fixture: ComponentFixture<DemoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DemoComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DemoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call function4() which should return 20', () => {
    component.ngOnInit();
    expect(component.function4).toHaveBeenCalled;
  });

  it('should increment "myNumber"', () => {
    component.function1();
    expect(component.myNumber).toBe(1);
    component.function1();
    expect(component.myNumber).toBe(2);
  });

  it('should concatenate the strings', () => {
    component.function2('testing', ' is fun');
    expect(component.myStrings).toBe('testing is fun');
  });

  it('should concatenate and return the string', () => {
    expect(component.function3('test')).toBe('testtest', 'funtion3 test failed.');
  });





});
