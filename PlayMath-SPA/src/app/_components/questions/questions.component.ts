import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/_models/Category';
import { ArticleService } from 'src/app/_services/article.service';
import { QuestionService } from 'src/app/_services/question.service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.scss']
})
export class QuestionsComponent implements OnInit {

  categories: Category[];
  activeCate = 0;

  constructor(private articleService: ArticleService, private questionServive: QuestionService) { }

  ngOnInit() {
    this.getCategories();
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

  onCategoryChange(category: Category){
    this.activeCate = category.id;
  }
  onPageChange(index){
    
  }

}
