import axios, { AxiosError } from 'axios';
import { BaseService } from './base-service';
import { ApiResponse } from '../interfaces/api-response';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Exam } from '../interfaces/exam';


@Injectable({
    providedIn: 'root',
  })
export class ExamService extends BaseService{
    constructor(private http: HttpClient) {
        super();
    }


    async getAllExams() : Promise<Exam[]> {
        let url = this.generateUrl('/exam/exams');
        const response = await axios.get<ApiResponse<Exam[]>>(url);
        let data = await response.data;
        return data.data;
    }

    async postExam(exam : Exam) : Promise<string>{
        let url = this.generateUrl('/exam/exam');
        const config = {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
              }
          };
        try {
           const response = await axios.post<ApiResponse<any>>(url, exam, config);
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