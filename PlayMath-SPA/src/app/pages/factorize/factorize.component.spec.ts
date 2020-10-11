/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FactorizeComponent } from './factorize.component';

describe('FactorizeComponent', () => {
  let component: FactorizeComponent;
  let fixture: ComponentFixture<FactorizeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FactorizeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FactorizeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
