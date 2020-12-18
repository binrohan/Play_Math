import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { faCheckCircle, faStar } from '@fortawesome/free-solid-svg-icons';
import { Answer } from 'src/app/_models/Answer';
import { Question } from 'src/app/_models/Question';
import { AnswerService } from 'src/app/_services/answer.service';
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

  answers: Answer[];
  answerCount: number;

  isSolved = false;
  isBestAnswer = false;

  question: Question;
  questionId: number;

  params = {
    pageIndex: 0,
    pageSize: 5,
    filter: '',
    categoryBy: 0,
  };

  totalPage = [];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private questionService: QuestionService,
    private authService: AuthService,
    private answerService: AnswerService
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

  onBestAnswerClicked(a: Answer) {
    const model: any = {
      body: a.body,
      answererId: a.answeredBy.id,
      questionId: this.questionId
    };
    this.answerService.markBestAnswer(model, a.id, this.authService.decodedToken.nameid).subscribe(() => {
      this.getAnswers();
    }, (error) => {
      console.log('Error updating start');
    });
  }

  onPageChange(index) {
    this.params.pageIndex = index;
    this.getAnswers();
  }

  postAnswer() {
    this.answer.answererId = this.authService.decodedToken.nameid;
    this.answer.questionId = this.questionId;
    this.answerService.addAnswer(this.answer).subscribe(() => {
      this.getAnswers();
      console.log('answer posted');
    }, (error) => {
      console.log('answer post failed');
    });
  }

  getQuestion() {
    this.questionService.getQuestion(this.questionId).subscribe(
      (data) => {
        this.question = data; console.log(this.question);
        console.log('Article Load Successfully');
        console.log(this.question);
        this.getAnswers();
      },
      (error) => {
        console.log('Article failed to load');
      }
    );
  }

  getAnswers(){
    this.answerService.getAnswers(this.params, this.questionId).subscribe((data) => {
      this.answers = data.answers;
      this.answerCount = data.length;
      this.pageCalc(data.length);
      console.log(this.answers);
    }, (error) => {
      console.log('Failed to load answers');
    });
  }

  pageCalc(length: number) {
    this.totalPage = Array(Math.ceil(length / this.params.pageSize))
      .fill(1)
      .map((x, i) => i);
  }
}
