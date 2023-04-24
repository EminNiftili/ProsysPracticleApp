import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { MainComponentComponent as MainComponent } from './components/main-component/main-component.component';
import { StudentComponent } from './components/student-component/student-component.component';
import { ExamComponentComponent as ExamComponent } from './components/exam-component/exam-component.component';
import { LessonComponentComponent as LessonComponent } from './components/lesson-component/lesson-component.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    StudentComponent,
    ExamComponent,
    LessonComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      {path: '', component: MainComponent},
      {path: 'student', component: StudentComponent},
      {path: 'lesson', component: LessonComponent},
      {path: 'exam', component: ExamComponent},
    ]),
    MatTableModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
