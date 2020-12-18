/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MeanComponent } from './mean.component';

describe('MeanComponent', () => {
  let component: MeanComponent;
  let fixture: ComponentFixture<MeanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MeanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MeanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
