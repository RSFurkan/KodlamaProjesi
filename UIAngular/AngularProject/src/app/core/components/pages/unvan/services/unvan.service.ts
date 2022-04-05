import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment'; 
import { Unvan } from '../models/unvan';


@Injectable({
    providedIn: 'root'
})

export class UnvanService
{

    constructor(private httpClient: HttpClient) { }
    getList(): Observable<Unvan[]> {
        return this.httpClient.get<Unvan[]>(environment.getApiUrl + '/unvan/getall')
    }

    add(obj: Unvan): Observable<any> {

        return this.httpClient.post(environment.getApiUrl + '/unvan/', obj, { responseType: 'text' });
    }

    update(obj: Unvan): Observable<any> {
        return this.httpClient.put(environment.getApiUrl + '/unvan/', obj, { responseType: 'text' });
    }
    delete(id: number) {
        return this.httpClient.request('delete', environment.getApiUrl + '/unvan/', { body: { id: id } });
      }
}