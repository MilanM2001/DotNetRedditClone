import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/models/post.model';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  posts: Array<Post> = [];

  constructor(private postService: PostService) {
    this.postService.GetAll().subscribe(post => {
      this.posts = post;
      console.log(post);
    });
   }

  ngOnInit(): void {
  }

}
