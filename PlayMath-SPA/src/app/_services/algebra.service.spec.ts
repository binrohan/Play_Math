/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AlgebraService } from './algebra.service';

describe('Service: Algebra', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AlgebraService]
    });
  });

  it('should ...', inject([AlgebraService], (service: AlgebraService) => {
    expect(service).toBeTruthy();
  }));
});
