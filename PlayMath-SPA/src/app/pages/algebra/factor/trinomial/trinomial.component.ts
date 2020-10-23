import { Component, OnInit } from '@angular/core';
import { Trinomial } from 'src/app/_models/_math.models/trinomial';
import { AlgebraService } from 'src/app/_services/algebra.service';

@Component({
  selector: 'app-trinomial',
  templateUrl: './trinomial.component.html',
  styleUrls: ['./trinomial.component.scss']
})
export class TrinomialComponent implements OnInit {

  isSolveClicked = false;
  solved: any;
  model = {
    a: 1,
    b: 7,
    c: 12,
    equation: 'xxxxx',
  };
  trinomial: Trinomial;

  constructor(private algebraService: AlgebraService) { }

  ngOnInit() {
  }

  solve() {
    console.log(this.model);
    this.isSolveClicked = true;

    this.trinomial = Object.assign({}, this.model);
    this.algebraService.getMaths(this.trinomial).subscribe(
      (data) => {
        console.log(data);
        this.solved = data;
      },
      (error) => {
        console.log(error);
      }
    );
  }

}
