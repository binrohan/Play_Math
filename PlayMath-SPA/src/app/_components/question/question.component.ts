import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { faCheckCircle, faStar } from '@fortawesome/free-solid-svg-icons';
import { Question } from 'src/app/_models/Question';
import { AuthService } from 'src/app/_services/auth.service';
import { CommentService } from 'src/app/_services/comment.service';
import { QuestionService } from 'src/app/_services/question.service';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss'],
})
export class QuestionComponent implements OnInit {
  faCheckCircle = faCheckCircle;
  faStar = faStar;

  answer: any = {};

  isSolved = false;
  isBestAnswer = false;

  question: Question;
  questionId: number;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private questionService: QuestionService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.questionId = parseInt(this.route.snapshot.paramMap.get('id'), 10);
    this.getQuestion();
  }

  onSolvedClicked() {
    this.question.isSolved = !this.question.isSolved;
    this.question.questioner = this.authService.decodedToken.nameid;
    this.question.categoryId = this.question.category.id;
    this.questionService
      .updateQuestion(this.question, this.questionId)
      .subscribe(
        (data) => {
          this.question = data;
        },
        (error) => {
          console.log('Update failed');
          this.question.isSolved = !this.question.isSolved;
        }
      );
  }

  onBestAnswerClicked() {
    this.isBestAnswer = !this.isBestAnswer;
  }

  onPageChange(index) {}

  postAnswer() {}

  getQuestion() {
    this.questionService.getQuestion(this.questionId).subscribe(
      (data) => {
        this.question = data; console.log(this.question);
        console.log('Article Load Successfully');
        console.log(this.question);
        // this.getAnswers();
      },
      (error) => {
        console.log('Article failed to load');
      }
    );
  }
}
