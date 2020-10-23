/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TrinomialComponent } from './trinomial.component';

describe('TrinomialComponent', () => {
  let component: TrinomialComponent;
  let fixture: ComponentFixture<TrinomialComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrinomialComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrinomialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
