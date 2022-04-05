import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LookUp } from '../models/lookUp';


@Injectable({
    providedIn: 'root'
  })
  export class LookUpService {

    constructor(private httpClient: HttpClient) { }

    
    getdepartmentlookup(): Observable<LookUp[]> {
        return this.httpClient.get<LookUp[]>(environment.getApiUrl + '/departman/getdepartmentlookup')
    }
    getpersonellookup(): Observable<LookUp[]> {
      return this.httpClient.get<LookUp[]>(environment.getApiUrl + '/personel/getpersonellookup')
  }
  }