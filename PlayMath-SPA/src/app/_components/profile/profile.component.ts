import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Article } from 'src/app/_models/Article';
import { Category } from 'src/app/_models/Category';
import { Question } from 'src/app/_models/Question';
import { ArticleService } from 'src/app/_services/article.service';
import { AuthService } from 'src/app/_services/auth.service';
import { QuestionService } from 'src/app/_services/question.service';
import { QuizService } from 'src/app/_services/quiz.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  user: any = {};
  users: any;
  totalPage = [];
  totalPageArticle = [];
  totalPageQuestion = [];
  articles: Article[];
  questions: Question[];
  userId: string;
  params = {
    pageIndex: 0,
    pageSize: 5,
    filter: '',
  };
  paramsArticle = {
    categoryBy: 0,
    byUserId: '',
    pageIndex: 0,
    pageSize: 5,
    filter: '',
  };
  paramsQuestion = {
    byUserId: '',
    pageIndex: 0,
    pageSize: 5,
    filter: '',
    categoryBy: 0
  };

  newCateName: string;
  categories: Category[];

  quiz = {
    questionDto: '',
    optionDto: [{answer: '', isCorrect: false}, {answer: '', isCorrect: false}, {answer: '', isCorrect: false}, {answer: '', isCorrect: false}]
  }

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private articleService: ArticleService,
    private questionService: QuestionService,
    private router: Router,
    private quizService: QuizService
  ) {}

  ngOnInit() {
    if(!this.loggedIn()){
      this.router.navigate(['/login']);
      return false;
    }
    this.getUser(this.authService.decodedToken.nameid);
    this.getUsers();
    this.userId = this.authService.decodedToken.nameid;
    this.paramsArticle.byUserId = this.userId;
    this.paramsQuestion.byUserId = this.userId;
    this.getArticles();
    this.getQuestion();
    this.getCategories();
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  getUser(id: string) {
    this.userService.getUser(id).subscribe(
      (data) => {
        this.user = data;
        console.log(this.user);
      },
      (error) => console.log('User failed to load')
    );
  }

  getUsers() {
    this.userService.getUsers(this.params).subscribe(
      (data) => {
        this.users = data.users;
        this.pageCalc(data.length, 'u');
        console.log(this.users);
      },
      (error) => {
        console.log('failed');
      }
    );
  }

  search() {
    this.getUsers();
  }

  searchArticle() {
    this.getArticles();
  }

  searchQuestion() {
    this.getQuestion();
  }

  onPageChange(index) {
    this.params.pageIndex = index;
    this.getUsers();
  }

  onPageChangeArticle(index) {
    this.paramsArticle.pageIndex = index;
    this.getArticles();
  }

  onPageChangeQuestion(index) {
    this.paramsQuestion.pageIndex = index;
    this.getQuestion();
  }

  pageCalc(length: number, name: string) {
    if(name === 'u'){
      this.totalPage = Array(Math.ceil(length / this.params.pageSize))
        .fill(1)
        .map((x, i) => i);
    } else if (name === 'a') {
      this.totalPageArticle = Array(Math.ceil(length / this.params.pageSize))
        .fill(1)
        .map((x, i) => i);
    } else if (name === 'q') {
      this.totalPageQuestion = Array(Math.ceil(length / this.params.pageSize))
        .fill(1)
        .map((x, i) => i);
    }
  }

  getArticles() {
    this.articleService.getArticles(this.paramsArticle).subscribe(
      (data) => {
        this.articles = data.articles;
        this.pageCalc(data.length, 'a');
        console.log(this.articles);
      },
      (error) => {
        console.log('Failed to get articles');
      }
    );
  }

  getQuestion() {
    this.questionService.getQuestions(this.paramsQuestion).subscribe(
      (data) => {
        this.questions = data.questions;
        this.pageCalc(data.length, 'q');
        console.log(this.questions);
      },
      (error) => {
        console.log('Failed to get Question');
      }
    );
  }

  updateUser(){
    this.userService.updateUser(this.userId, {userName: this.user.userName, id: this.userId, email: this.user.email}).subscribe((data) => {
      this.user = data;
    }, (error) => {
      console.log('Error updating user');
    });
  }

  deleteUser(){
    this.userService.deleteUser(this.userId, this.authService.decodedToken.nameid).subscribe(() => {
      console.log('User Removed');
    }, (error) => {
      console.log('User Removed Failed');
    });
  }

  removeCate(id: number){
    this.articleService.removeCate(id).subscribe(()=>{
      console.log('Removed');
      this.getCategories();
    }, (error) => {
      console.log('Removed failed');
    })
  }

  addCate(){
    if(this.newCateName === undefined || this.newCateName === '')
      return false;

    this.articleService.addCate({category: this.newCateName}).subscribe(() => {
      console.log('Category Added');
      this.getCategories();
    }, (error)=> {
      console.log('Category add failed');
    })
  }

  getCategories() {
    this.articleService.getCategories().subscribe(
      (data) => {
        this.categories = data;
      },
      (error) => {
        console.log('Failed to get categories');
      }
    );
  }


  addQuiz(){
    console.log(this.quiz);
    this.quizService.addQuiz(this.quiz).subscribe(() => {
      console.log('Question added to the database');
    }, (error) => {
      console.log('Question failed to add');
    })
  }
}
