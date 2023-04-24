import { Component, OnInit } from '@angular/core';
import { Exam } from 'src/app/interfaces/exam';
import { ExamService } from 'src/app/services/exam-service';

@Component({
  selector: 'app-exam-component',
  templateUrl: './exam-component.component.html',
  styleUrls: ['./exam-component.component.scss']
})
export class ExamComponentComponent implements OnInit{

  displayedColumns: string[] = ['lessonCode', 'studentNumber', 'examDate', 'examResult'];
  dataSource!: Exam[];

  lessonCode!: string;
  studentNumber!: string;
  examDate!: Date;
  examResult!: string;

  errorMessage!: string;

  constructor(private examService : ExamService){

  }


  async ngOnInit(): Promise<void> {
    let exams = await this.examService.getAllExams();
    this.dataSource = exams;
  }
  async sumbitExam(){
    var studentNumber = Number(this.studentNumber == undefined ? '0' : this.studentNumber);
    var examResult = Number(this.examResult == undefined ? '0' : this.examResult);
    
    var exam = new Exam();
    exam.lessonCode = this.lessonCode;
    exam.studentNumber = studentNumber;
    exam.examDate = this.examDate;
    exam.examResult = examResult;

    var response = await this.examService.postExam(exam);
    if(response == ""){
      location.reload();
    }
    else{
      this.errorMessage = response;
    }
  }
}
