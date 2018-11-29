import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Map } from '../_models/map';

@Injectable({
    providedIn: 'root'
})
export class MapService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) {

    }

    getMaps(): Observable<Map[]> {
        return this.http.get<Map[]>(this.baseUrl + 'maps');
    }

    getMap(id): Observable<Map> {
        return this.http.get<Map>(this.baseUrl + 'maps/' + id)
    }
}