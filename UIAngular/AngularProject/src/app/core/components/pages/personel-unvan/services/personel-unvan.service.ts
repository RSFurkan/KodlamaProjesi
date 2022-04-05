import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment'; 
import { PersonelUnvan } from '../models/personel-unvan';

@Injectable({
    providedIn: 'root'
})

export class PersonelUnvanService
{

    constructor(private httpClient: HttpClient) { }
    getList(): Observable<PersonelUnvan[]> {
        return this.httpClient.get<PersonelUnvan[]>(environment.getApiUrl + '/personelunvan/getall')
    }

    add(obj: PersonelUnvan): Observable<any> {

        return this.httpClient.post(environment.getApiUrl + '/personelunvan/', obj, { responseType: 'text' });
    }

    update(obj: PersonelUnvan): Observable<any> {
        return this.httpClient.put(environment.getApiUrl + '/personelunvan/', obj, { responseType: 'text' });
    }
    delete(id: number) {
        return this.httpClient.request('delete', environment.getApiUrl + '/personelunvan/', { body: { id: id } });
      }
}
