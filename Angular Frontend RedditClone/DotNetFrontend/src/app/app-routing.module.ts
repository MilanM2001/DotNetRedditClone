import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { CommunitiesComponent } from './components/community/communities/communities.component';
import { CommunityAddComponent } from './components/community/community-add/community-add.component';
import { CommunityEditComponent } from './components/community/community-edit/community-edit.component';
import { CommunitySuspendComponent } from './components/community/community-suspend/community-suspend.component';
import { CommunityViewComponent } from './components/community/community-view/community-view.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { NotFoundComponent } from './components/notfound/notfound.component';
import { PostAddComponent } from './components/post/post-add/post-add.component';
import { PostEditComponent } from './components/post/post-edit/post-edit.component';
import { PostViewComponent } from './components/post/post-view/post-view.component';
import { RuleAddComponent } from './components/rule/rule-add/rule-add.component';
import { RuleEditComponent } from './components/rule/rule-edit/rule-edit.component';
import { MyProfileComponent } from './components/user/my-profile/my-profile.component';

const routes: Routes = [
  {
    path: 'mainPage',
    component: HomeComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'communities',
    component: CommunitiesComponent
  },
  {
    path: 'community-view/:communityId',
    component: CommunityViewComponent
  },
  {
    path: 'community-edit/:communityId',
    component: CommunityEditComponent
  },
  {
    path: 'community-suspend/:communityId',
    component: CommunitySuspendComponent
  },
  {
    path: 'community/add',
    component: CommunityAddComponent
  },
  {
    path: 'post-view/:postId',
    component: PostViewComponent
  },
  {
    path: 'post-add/:communityId',
    component: PostAddComponent
  },
  {
    path: 'post-edit/:postId',
    component: PostEditComponent
  },
  {
    path: 'myProfile',
    component: MyProfileComponent
  },
  {
    path: 'rule-edit/:ruleId',
    component: RuleEditComponent
  },
  {
    path: 'rule-add/:communityId',
    component: RuleAddComponent
  },
  {
    path: '404',
    component: NotFoundComponent
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
