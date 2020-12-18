/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MedianComponent } from './median.component';

describe('MedianComponent', () => {
  let component: MedianComponent;
  let fixture: ComponentFixture<MedianComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MedianComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MedianComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
