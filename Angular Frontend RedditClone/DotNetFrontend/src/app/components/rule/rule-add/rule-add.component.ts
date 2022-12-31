import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Community } from 'src/app/models/community.model';
import { Rule } from 'src/app/models/rule.model';
import { CommunityService } from 'src/app/services/community.service';

@Component({
  selector: 'app-rule-add',
  templateUrl: './rule-add.component.html',
  styleUrls: ['./rule-add.component.css']
})
export class RuleAddComponent implements OnInit {

  ruleFormGroup: FormGroup = new FormGroup({
    ruleName: new FormControl(''),
    ruleDescription: new FormControl('')
  });

  community_id: number = 0;
  community: Community = new Community();
  newRules: Rule[] = [];

  constructor(private communityService: CommunityService,
              private route: ActivatedRoute,
              private formBuilder: FormBuilder,
              private location: Location) { }

  submittedRule = false;

  ngOnInit(): void {
    this.community = new Community();
    this.community_id = Number(this.route.snapshot.paramMap.get('communityId'));

    this.ruleFormGroup = this.formBuilder.group({
      ruleName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(15)]],
      ruleDescription: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]]
    });

    this.communityService.GetSingle(this.community_id)
      .subscribe({
        next: (data: Community) => {
          console.log(data);
          this.community = data;
        },
        error: (error) => {
          console.error(error);
        }
      })
  }

  addRule() {
    this.submittedRule = true;

    if (this.ruleFormGroup.invalid) {
      return;
    }

    let addRule: Rule = new Rule();
    addRule.name = this.ruleFormGroup.get('ruleName')?.value;
    addRule.description = this.ruleFormGroup.get('ruleDescription')?.value;
    this.newRules.push(addRule);
    this.ruleFormGroup.controls['ruleName'].reset();
    this.ruleFormGroup.controls['ruleDescription'].reset();
  }

  get ruleGroup(): { [key: string]: AbstractControl } {
    return this.ruleFormGroup.controls;
  }

  onSubmit() {
    this.community.rules = this.newRules;

    this.communityService.AddRule(this.community_id, this.community)
      .subscribe({
        next: (data) => {
          console.log(data);
          this.location.back();
        },
        error: (error) => {
          console.error(error);
        }
      })
  }

}
