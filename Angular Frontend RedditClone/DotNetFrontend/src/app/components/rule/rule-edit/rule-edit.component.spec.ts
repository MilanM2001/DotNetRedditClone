import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RuleEditComponent } from './rule-edit.component';

describe('RuleEditComponent', () => {
  let component: RuleEditComponent;
  let fixture: ComponentFixture<RuleEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RuleEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RuleEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
