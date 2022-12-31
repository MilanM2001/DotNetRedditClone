import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Rule } from '../models/rule.model';

@Injectable({
  providedIn: 'root'
})
export class RuleService {
  private url = "Rule";
  
  constructor(private http: HttpClient) { }

  public GetSingle(ruleId: number): Observable<Rule> {
    return this.http.get<Rule>(`${environment.baseApiUrl}/${this.url}/Single/` + ruleId);
  }

  public Update(ruleId: number, rule: Rule) {
    return this.http.put<Rule>(`${environment.baseApiUrl}/${this.url}/Update/` + ruleId, rule);
  }

  public Delete(ruleId: number) {
    return this.http.delete(`${environment.baseApiUrl}/${this.url}/` + ruleId);
  }
}
