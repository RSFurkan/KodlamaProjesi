
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Departman } from '../models/departman';

@Injectable({
    providedIn: 'root'
})

export class DepartmnetService {
    constructor(private httpClient: HttpClient) { }

    getDepartmentList(): Observable<Departman[]> {
        return this.httpClient.get<Departman[]>(environment.getApiUrl + '/departman/getall')
    }

    addDepartment(dep: Departman): Observable<any> {

        return this.httpClient.post(environment.getApiUrl + '/departman/', dep, { responseType: 'text' });
    }

    updateDepartment(dep: Departman): Observable<any> {
        return this.httpClient.put(environment.getApiUrl + '/departman/', dep, { responseType: 'text' });
    }
    deleteDepartment(id: number) {
        return this.httpClient.request('delete', environment.getApiUrl + '/departman/', { body: { id: id } });
      }

}