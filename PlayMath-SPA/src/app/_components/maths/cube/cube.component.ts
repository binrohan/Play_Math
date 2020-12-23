import { Component, OnInit } from '@angular/core';
import { MathService } from 'src/app/_services/math.service';

@Component({
  selector: 'app-cube',
  templateUrl: './cube.component.html',
  styleUrls: ['./cube.component.scss']
})
export class CubeComponent implements OnInit {
  isSolveClicked = false;
  solved: any;
  model = {
    a: 1,
    b: 7,
    equation: 'xxxxx',
  };

  success = true;

  constructor(private mathService: MathService) { }

  ngOnInit() {
  }

  solve() {
    console.log(this.model);
    this.isSolveClicked = true;

   
    this.mathService.getCube(this.model).subscribe(
      (data) => {
        console.log(data);
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
