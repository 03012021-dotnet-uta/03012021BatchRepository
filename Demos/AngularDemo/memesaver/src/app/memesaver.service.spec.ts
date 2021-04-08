import { TestBed } from '@angular/core/testing';

import { MemesaverService } from './memesaver.service';

describe('MemesaverService', () => {
  let service: MemesaverService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MemesaverService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
