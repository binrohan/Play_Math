import { Component, OnInit } from '@angular/core';
import { Quadratic } from 'src/app/_models/_math.models/quadratic';
import { AlgebraService } from 'src/app/_services/algebra.service';

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
  quadratic: Quadratic;
  success = false;

  constructor(private algebraService: AlgebraService) { }

  ngOnInit() {
  }

  solve() {
    console.log(this.model);
    this.isSolveClicked = true;

    this.quadratic = Object.assign({}, this.model);
    this.algebraService.getQuadratic(this.quadratic).subscribe(
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
