import { Component, OnInit } from '@angular/core';
import { MathService } from 'src/app/_services/math.service';

@Component({
  selector: 'app-quadratic',
  templateUrl: './quadratic.component.html',
  styleUrls: ['./quadratic.component.scss']
})
export class QuadraticComponent implements OnInit {

  isSolveClicked = false;
  solved: any;
  model = {
    a: 1,
    b: 7,
    c: 12,
    d: 0
  };
  success = false;

  constructor(private mathService: MathService) { }

  ngOnInit() {
  }

  solve() {
    console.log(this.model);
    this.isSolveClicked = true;

    
    this.mathService.getQuadratic(this.model).subscribe(
      (data) => {
        this.solved = data;
        this.success = true;
      },
      (error) => {
        console.log(error);
        this.success = false;
      }
    );
  }

}
