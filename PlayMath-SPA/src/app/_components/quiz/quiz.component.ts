import { Component, OnInit } from '@angular/core';
import { QuizService } from 'src/app/_services/quiz.service';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.scss'],
})
export class QuizComponent implements OnInit {
  quizIds: number[];
  index = 0;
  quiz: any = {};
  correctAnswerCount = 0;
  started = false;
  retry = false;
  seletedOption = undefined;
  open = true;

  constructor(private quizService: QuizService) {}

  ngOnInit() {
    this.requestQuiz();
  }

  requestQuiz() {
    this.quizService.requestQuiz().subscribe(
      (data) => {
        this.quizIds = data;
      },
      (error) => {
        console.log('Quiz Request Failed');
      }
    );
  }

  nextQuiz() {
    if (this.index !== 0) {
      this.check();
    }

    if (this.index > 4) {
      this.result();
      return false;
    }

    this.quizService.getQuiz(this.quizIds[this.index]).subscribe(
      (data) => {
        console.log('Quiz loaded');
        this.quiz = data;
        this.index++;
      },
      (error) => {
        console.log('Quiz load failed');
      }
    );
  }

  result() {
    this.retry = true;
    this.index = 0;
    this.started = false;
  }
  check() {
    console.log(this.seletedOption);
    if (this.quiz.options[this.seletedOption].isCorrect === true) {
      this.correctAnswerCount++;
    }
  }
}
