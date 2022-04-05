
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment'; 
import { PersonelOrnekDataTable } from '../personel-ornek-data-table';

@Injectable({
    providedIn: 'root'
})

export class PersonelOrnekDataTableService
{
    constructor(private httpClient: HttpClient) { }
    getList(): Observable<PersonelOrnekDataTable[]> {
        return this.httpClient.get<PersonelOrnekDataTable[]>(environment.getApiUrl + '/personelornekdatatable/getall')
    }

    add(obj: PersonelOrnekDataTable): Observable<any> {

        return this.httpClient.post(environment.getApiUrl + '/personelornekdatatable/', obj, { responseType: 'text' });
    }

    update(obj: PersonelOrnekDataTable): Observable<any> {
        return this.httpClient.put(environment.getApiUrl + '/personelornekdatatable/', obj, { responseType: 'text' });
    }
    delete(id: number) {
        return this.httpClient.request('delete', environment.getApiUrl + '/personelornekdatatable/', { body: { id: id } });
      }
}