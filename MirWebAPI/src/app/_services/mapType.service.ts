import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MapType } from '../_models/mapType';

@Injectable({
    providedIn: 'root'
})
export class MapTypeService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) {

    }

    getTypes(): Observable<MapType[]> {
        return this.http.get<MapType[]>(this.baseUrl + 'types')
    }

    getParamsTypes(type): Observable<MapType[]> {
        return this.http.get<MapType[]>(this.baseUrl + 'types/find?type=' + type)
    }
}