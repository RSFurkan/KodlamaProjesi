
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment'; 
import { Personel } from '../models/personel';

@Injectable({
    providedIn: 'root'
})

export class PersonelService
{
    constructor(private httpClient: HttpClient) { }
    getList(): Observable<Personel[]> {
        return this.httpClient.get<Personel[]>(environment.getApiUrl + '/personel/getall')
    }

    add(obj: Personel): Observable<any> {

        return this.httpClient.post(environment.getApiUrl + '/personel/', obj, { responseType: 'text' });
    }

    update(obj: Personel): Observable<any> {
        return this.httpClient.put(environment.getApiUrl + '/personel/', obj, { responseType: 'text' });
    }
    delete(id: number) {
        return this.httpClient.request('delete', environment.getApiUrl + '/personel/', { body: { id: id } });
      }
}