import { Component, OnInit } from '@angular/core';
import { Mode } from 'src/app/_models/_math.models/mode';
import { ModeSolved } from 'src/app/_models/_math.models/mode-solved';
import { PreAlgebraService } from 'src/app/_services/pre-algebra.service';

@Component({
  selector: 'app-mode',
  templateUrl: './mode.component.html',
  styleUrls: ['./mode.component.scss'],
})
export class ModeComponent implements OnInit {
  model = {
    numbers: '',
  };
  success = true;
  isSolveClicked = false;
  mode: Mode;
  solution: ModeSolved = {
    numbers: [],
    result: 0,
  };
  placeholder = '99,86,87,88,111,86,103,87,94,78,77,85,86';
  sortedNumbers: number[] = [];
  isLengthEven = false;
  index: number[] = [];
  medianResult: number;
  sum = 0;

  constructor(private preAlgebraService: PreAlgebraService) {}

  ngOnInit() {}

  solve() {
    this.isSolveClicked = true;

    if (this.model.numbers === '') {
      this.model.numbers = this.placeholder;
    }
    console.log(this.model);

    this.mode = Object.assign({}, this.model);
    this.preAlgebraService.getMode(this.mode).subscribe(
      (data) => {
        this.solution = data;
        this.median(this.solution.numbers);
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

  median(numbers: number[]) {
    this.sortedNumbers = Object.assign([], numbers);
    this.sortedNumbers.sort((a, b) => a - b);
    this.sortedNumbers.forEach(element => {
      this.sum = element + this.sum;
    });
    const len = this.sortedNumbers.length;

    if (len % 2 !== 0) {
      this.index = [Math.floor(len / 2)];
      this.isLengthEven = false;

      this.medianResult = this.sortedNumbers[this.index[0]];
    } else {
      this.index = [len / 2, len / 2 + 1];
      this.isLengthEven = true;

      this.medianResult = (this.sortedNumbers[this.index[0]] + this.sortedNumbers[this.index[1]]) / 2;
    }


  }
}
