import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { MatCardModule } from '@angular/material/card';
import { MatButtonModule} from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import { MatDividerModule } from '@angular/material/divider';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PostItemComponent } from './components/post/post-item/post-item.component';
import { PostListComponent } from './components/post/post-list/post-list.component';
import { HeaderComponent } from './components/header/header.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './components/home/home.component';
import { CommunityItemComponent } from './components/community/community-item/community-item.component';
import { CommunityListComponent } from './components/community/community-list/community-list.component';
import { CommunitiesComponent } from './components/community/communities/communities.component';
import { CommunityViewComponent } from './components/community/community-view/community-view.component';
import { PostViewComponent } from './components/post/post-view/post-view.component';
import { PostAddComponent } from './components/post/post-add/post-add.component';
import { CommunityEditComponent } from './components/community/community-edit/community-edit.component';
import { CommunitySuspendComponent } from './components/community/community-suspend/community-suspend.component';
import { CommunityAddComponent } from './components/community/community-add/community-add.component';
import { PostEditComponent } from './components/post/post-edit/post-edit.component';
import { NotFoundComponent } from './components/notfound/notfound.component';
import { RuleEditComponent } from './components/rule/rule-edit/rule-edit.component';
import { RuleAddComponent } from './components/rule/rule-add/rule-add.component';
import { LoginComponent } from './components/login/login.component';
import { AuthInterceptor } from './services/auth.interceptor';
import { MyProfileComponent } from './components/user/my-profile/my-profile.component';

@NgModule({
  declarations: [
    AppComponent,
    PostItemComponent,
    PostListComponent,
    HeaderComponent,
    HomeComponent,
    CommunityItemComponent,
    CommunityListComponent,
    CommunitiesComponent,
    CommunityViewComponent,
    CommunityViewComponent,
    PostViewComponent,
    PostAddComponent,
    CommunityEditComponent,
    CommunitySuspendComponent,
    CommunityAddComponent,
    PostEditComponent,
    NotFoundComponent,
    RuleEditComponent,
    RuleAddComponent,
    LoginComponent,
    MyProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    MatFormFieldModule,
    MatSelectModule,
    MatDividerModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
