import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {

  constructor(private authService: AuthService,
              private route: ActivatedRoute,
              private router: Router) { }

  user: User = new User();

  ngOnInit(): void {
    this.authService.GetMe()
      .subscribe({
        next: (data: User) => {
          this.user = data;
          console.log(this.user);
        },
        error: (error) => {
          console.log(error);
        }
      })
  }

}
