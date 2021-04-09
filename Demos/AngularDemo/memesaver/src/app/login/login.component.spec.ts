import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Observable, of } from 'rxjs';
import { EditPerson } from '../edit-person';
import { MemesaverService } from '../memesaver.service';
import { StringPerson } from '../string-person';

import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  /**Create this class to represent the service. 
   * You only need to implement the minimum of what 
   * the component will need to pass the tests
   * so if the service has 10 functions and this
   * component only uses 3, then you only need
   * to create those 3 fake methods
    */
  class memesaverServiceStub {
    login(): Observable<StringPerson> {
      return of({
        personId: 'guid', fname: 'Mwq', lname: 'A',
        userName: 'R', passwordHash: 'K', memberSince: new Date(),
        memes: [], memesILiked: []
      });
    }
    EditPerson(): Observable<boolean> {
      return of(false);
    }
  };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      providers: [LoginComponent, { provide: MemesaverService, useClass: memesaverServiceStub }],
      //declarations: [LoginComponent],
      //imports: [HttpClientTestingModule]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should give \'stringPerson\' the fname of "M"', () => {
    component.login();
    expect(component.stringPerson.fname).toBe("Mwq");
  });

  it('should return false to myBool from ChangedPerson()', () => {
    const editPerson: EditPerson = {
      personId: 'guid', fname: 'M', lname: 'A',
      username: 'R', newPassword: 'O', passwordHash: 'K', newUsername: 'O'
    };
    component.ChangedPerson(editPerson);
    expect(component.myBool).toBeFalsy;
    expect(component.ChangedPerson(editPerson)).toHaveBeenCalled;// make sure the methos was called.
  });

  it('should have a <p> that says "This is login component"', () => {
    const bannerElement: HTMLElement = fixture.nativeElement;
    const p = bannerElement.querySelector('p');
    expect(p.textContent).toEqual('This is login component');
  });

  it('should have a <p> that says "This is login component"', () => {
    const bannerElement: HTMLElement = fixture.nativeElement;
    const p = bannerElement.querySelector('p');
    expect(p.textContent).toContain('This is login');
  });
});
