import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { LoginDTO } from 'src/app/dto/loginDTO';
import { AuthService } from 'src/app/services/auth.service';

interface DisplayMessage {
  msgType: string;
  msgBody: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  title = 'Login to Reddit';
  formGroup: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  });

  constructor(
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder
  ) { }

  submitted = false;

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      username: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]],
      password: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]],
    });
  }

  get loginGroup(): { [key: string]: AbstractControl } {
    return this.formGroup.controls;
  }

  onSubmit() {
    this.submitted = true;

    if (this.formGroup.invalid) {
      return;
    }

    let login: LoginDTO = new LoginDTO();

    login.username = this.formGroup.get('username')?.value;
    login.password = this.formGroup.get('password')?.value;

    this.authService.login(login)
      .subscribe({
        next: (token: string) => {
          localStorage.setItem('authToken', token);
          this.router.navigate(['/mainPage']);
        }
      })

  }

}
