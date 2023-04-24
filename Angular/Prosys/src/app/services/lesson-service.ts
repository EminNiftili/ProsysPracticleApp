import axios, { AxiosError } from 'axios';
import { BaseService } from './base-service';
import { ApiResponse } from '../interfaces/api-response';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Lesson } from '../interfaces/lesson';


@Injectable({
    providedIn: 'root',
  })
export class LessonService extends BaseService{
    constructor(private http: HttpClient) {
        super();
    }


    async getAllLessons() : Promise<Lesson[]> {
        let url = this.generateUrl('/lesson/lessons');
        const response = await axios.get<ApiResponse<Lesson[]>>(url);
        let data = await response.data;
        return data.data;
    }

    async postLesson(lesson : Lesson) : Promise<string>{
        let url = this.generateUrl('/lesson/lesson');
        const config = {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
              }
          };
          try {
            const response = await axios.post<ApiResponse<any>>(url, lesson, config);
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