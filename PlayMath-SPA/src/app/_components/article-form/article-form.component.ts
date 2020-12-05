import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-article-form',
  templateUrl: './article-form.component.html',
  styleUrls: ['./article-form.component.scss']
})
export class ArticleFormComponent implements OnInit {

  articleForm: FormGroup;

  constructor(private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.createArticleForm();
  }

  createArticleForm(){
    this.articleForm = this.fb.group({
      title: ['', Validators.required],
      subtitle: ['', Validators.maxLength(25)],
      category: ['', Validators.required],
      write: ['', Validators.required]
    });
  }

  postArticle(){
    console.log(this.articleForm.value);
  }

}
