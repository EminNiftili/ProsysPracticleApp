import axios, { AxiosError } from 'axios';
import { BaseService } from './base-service';
import { ApiResponse } from '../interfaces/api-response';
import { Student } from '../interfaces/student';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
    providedIn: 'root',
  })
export class StudentService extends BaseService{
    constructor(private http: HttpClient) {
        super();
    }


    async getAllStudents() : Promise<Student[]> {
        let url = this.generateUrl('/student/students');
        const response = await axios.get<ApiResponse<Student[]>>(url);
        let data = await response.data;
        return data.data;
    }

    async postStudent(student : Student) : Promise<string>{
        let url = this.generateUrl('/student/student');
        const config = {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
              }
          };
          try {
            const response = await axios.post<ApiResponse<any>>(url, student, config);
            let data = await response.data;
             if(data.statusCode == 200){
                 return "";
             }
             else{
                 return data.message;
             }
         } 
         catch (error) {
             let axiousError = error as AxiosError<ApiResponse<any>>;
             return JSON.stringify(axiousError?.response?.data?.message).replaceAll('"','');
         }
    }
}