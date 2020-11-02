import { Component, OnInit } from '@angular/core';
import { Mode } from 'src/app/_models/_math.models/mode';
import { PreAlgebraService } from 'src/app/_services/pre-algebra.service';

@Component({
  selector: 'app-mode',
  templateUrl: './mode.component.html',
  styleUrls: ['./mode.component.scss']
})
export class ModeComponent implements OnInit {

  model = {
    numbers: ''
  };
  success = true;
  isSolveClicked = false;
  mode: Mode;
  solution: any = {};
  placeholder = '99,86,87,88,111,86,103,87,94,78,77,85,86';

  constructor(private preAlgebraService: PreAlgebraService) { }

  ngOnInit() {
  }

  solve(){
    this.isSolveClicked = true;

    if (this.model.numbers === ''){
      this.model.numbers = this.placeholder;
    }
    console.log(this.model);


    this.mode = Object.assign({}, this.model);
    this.preAlgebraService.getMode(this.mode).subscribe(
      (data) => {
        this.solution = data;
      },
      (error) => {
        this.success = false;
      }
    );
  }

  checkInputChar(event){
    const k = event.charCode;
    return ((k > 47 && k < 58) || k === 44);
  }

}
