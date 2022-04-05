import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LookUp } from 'src/app/core/models/lookUp';
import { environment } from 'src/environments/environment';
import { PersonelDepartman } from '../models/personel-departman';


@Injectable({
    providedIn: 'root'
})


export class PersonelDepartmentService {

    constructor(private httpClient: HttpClient) { }

    getList(): Observable<PersonelDepartman[]> {
        return this.httpClient.get<PersonelDepartman[]>(environment.getApiUrl + '/personeldepartman/getall')
    }

    add(obj: PersonelDepartman): Observable<any> {

        return this.httpClient.post(environment.getApiUrl + '/personeldepartman/', obj, { responseType: 'text' });
    }

    update(obj: PersonelDepartman): Observable<any> {
        return this.httpClient.put(environment.getApiUrl + '/personeldepartman/', obj, { responseType: 'text' });
    }
    delete(id: number) {
        return this.httpClient.request('delete', environment.getApiUrl + '/personeldepartman/', { body: { id: id } });
      }
      getdepartmentlookup(): Observable<LookUp[]> {
        return this.httpClient.get<LookUp[]>(environment.getApiUrl + '/departman/getdepartmentlookup')
    }
}
