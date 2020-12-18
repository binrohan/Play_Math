import { Component, OnInit } from '@angular/core';
import { MathService } from 'src/app/_services/math.service';

@Component({
  selector: 'app-mode',
  templateUrl: './mode.component.html',
  styleUrls: ['./mode.component.scss']
})
export class ModeComponent implements OnInit {


  model = {
    numbers: '',
  };
  success = true;
  isSolveClicked = false;
  mode: any = {};
  solution = {
    numbers: [],
    result: 0,
  };
  placeholder = '99,86,87,88,111,86,103,87,94,78,77,85,86';
  sortedNumbers: number[] = [];
  isLengthEven = false;
  index: number[] = [];
  medianResult: number;
  sum = 0;

  constructor(private mathService: MathService) { }

  ngOnInit() {
  }

  solve() {
    this.isSolveClicked = true;

    if (this.model.numbers === '') {
      this.model.numbers = this.placeholder;
    }
    console.log(this.model);

    this.mode = Object.assign({}, this.model);
    this.mathService.getMode(this.mode).subscribe(
      (data) => {
        this.solution = data;
        this.success = true;
      },
      (error) => {
        this.success = false;
      }
    );
  }

  checkInputChar(event) {
    const k = event.charCode;
    return (k > 47 && k < 58) || k === 44;
  }


}
