/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PreAlgebraService } from './pre-algebra.service';

describe('Service: PreAlgebra', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PreAlgebraService]
    });
  });

  it('should ...', inject([PreAlgebraService], (service: PreAlgebraService) => {
    expect(service).toBeTruthy();
  }));
});
