import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { MemesaverService } from './memesaver.service';

describe('MemesaverService', () => {
  let service: MemesaverService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ]
    });
    service = TestBed.inject(MemesaverService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
