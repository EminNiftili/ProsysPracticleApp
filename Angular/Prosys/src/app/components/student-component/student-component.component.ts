import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/interfaces/student';
import { StudentService } from 'src/app/services/student-service';


const ELEMENT_DATA: Student[] = [
  {number: 1, name: 'Hydrogen', surname: "1.0079", class: 1},
];

@Component({
  selector: 'app-student-component',
  templateUrl: './student-component.component.html',
  styleUrls: ['./student-component.component.scss']
})
export class StudentComponent implements OnInit {
  displayedColumns: string[] = ['number', 'name', 'surname', 'class'];
  dataSource!: Student[];
  display = "none";

  constructor(public studentService: StudentService){}

  addingStudent!: Student;

  errorMessage!: string;

  studentNumber!: string;
  studentClass!: string;
  studentName!: string;
  studentSurname!: string;


  async ngOnInit(): Promise<void> {
    let students = await this.studentService.getAllStudents();
    this.dataSource = students;
  }

  async sumbitStudent(){
    var studentNumber = Number(this.studentNumber == undefined ? '0' : this.studentNumber);
    var studentClass = Number(this.studentClass == undefined ? '0' : this.studentClass);
    
    this.addingStudent = new Student();
    this.addingStudent.class = studentClass;
    this.addingStudent.number = studentNumber;
    this.addingStudent.surname = this.studentSurname;
    this.addingStudent.name = this.studentName;

    var response = await this.studentService.postStudent(this.addingStudent);
    if(response == ""){
      location.reload();
    }
    else{
      this.errorMessage = response;
    }
  }

}
