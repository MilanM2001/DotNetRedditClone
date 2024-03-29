import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginDTO } from '../dto/loginDTO';
import { RegisterDTO } from '../dto/registerDTO';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private url = "Auth";
  constructor(private http: HttpClient) { }

  public register(registerDTO: RegisterDTO): Observable<User> {
    return this.http.post<User>(`${environment.baseApiUrl}/${this.url}/Register`, registerDTO);
  }

  public login(loginDTO: LoginDTO): Observable<string> {
    return this.http.post(`${environment.baseApiUrl}/${this.url}/Login`, loginDTO, { responseType: 'text' });
  }

  public GetMe(): Observable<User> {
    return this.http.get<User>(`${environment.baseApiUrl}/${this.url}/GetMe`);
}

  // public getMe(): Observable<string> {
  //   return this.http.get<string>(`${environment.baseApiUrl}/${this.url}/GetMe`);
  // }

}
