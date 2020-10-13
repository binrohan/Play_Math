import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-factorize',
  templateUrl: './factorize.component.html',
  styleUrls: ['./factorize.component.scss']
})
export class FactorizeComponent implements OnInit {

  isSolveClicked = false;
  equation: string;
  factorizeModel = {
    a: 1,
    b: 7,
    c: 12
  };

  constructor() { }

  ngOnInit() {
  }

  solve(){
    this.isSolveClicked = true;
    this.equation = this.factorizeModel.a.toString() + this.factorizeModel.b.toString() + this.factorizeModel.c.toString();
  }

}
