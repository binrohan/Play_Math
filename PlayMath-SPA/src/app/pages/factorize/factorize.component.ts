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
    a: 0,
    b: 0,
    c: 0
  };

  constructor() { }

  ngOnInit() {
  }

  solve(){
    console.log('solved clicked');
    this.isSolveClicked = true;
    console.log(this.isSolveClicked);
    this.equation = this.factorizeModel.a.toString();
    console.log(this.equation);
  }

}
