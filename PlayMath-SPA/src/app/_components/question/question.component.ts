import { Component, OnInit } from '@angular/core';
import { faCheckCircle, faStar } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent implements OnInit {

  faCheckCircle = faCheckCircle;
  faStar = faStar;

  answer: any = {};

  isSolved = false;
  isBestAnswer = false;

  constructor() { }

  ngOnInit() {
  }

  onSolvedClicked(){
    this.isSolved = !this.isSolved;
  }

  onBestAnswerClicked(){
    this.isBestAnswer = !this.isBestAnswer;
  }

  onPageChange(index){

  }

  postAnswer(){
    
  }

}
