import { Component, OnInit } from '@angular/core';
import { Lesson } from 'src/app/interfaces/lesson';
import { LessonService } from 'src/app/services/lesson-service';

@Component({
  selector: 'app-lesson-component',
  templateUrl: './lesson-component.component.html',
  styleUrls: ['./lesson-component.component.scss']
})
export class LessonComponentComponent implements OnInit{

  displayedColumns: string[] = ['code', 'name', 'class', 'teacherName', 'teacherSurname'];
  dataSource!: Lesson[];

  errorMessage!: string;
  
  lessonCode!: string;
  lessonClass!: string;
  lessonName!: string;
  teacherName!: string;
  teacherSurname!: string;


  constructor(public lessonService: LessonService){}

  async ngOnInit(): Promise<void> {
    let lessons = await this.lessonService.getAllLessons();
    this.dataSource = lessons;
  }

  async sumbitLesson(){
    var lessonClass = Number(this.lessonClass == undefined ? '0' : this.lessonClass);
    
    var lesson = new Lesson();
    lesson.code = this.lessonCode;
    lesson.name = this.lessonName;
    lesson.class = lessonClass;
    lesson.teacherName = this.teacherName;
    lesson.teacherSurname = this.teacherSurname;

    var response = await this.lessonService.postLesson(lesson);
    if(response == ""){
      location.reload();
    }
    else{
      this.errorMessage = response;
    }
  }
}
