import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-bg-button',
  templateUrl: './bg-button.component.html',
  styleUrls: ['./bg-button.component.scss']
})
export class BgButtonComponent implements OnInit {

  @Input() buttonName: string;

  constructor() { }

  ngOnInit() {
  }

}
