/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ABComponent } from './a-b.component';

describe('ABComponent', () => {
  let component: ABComponent;
  let fixture: ComponentFixture<ABComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ABComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ABComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
