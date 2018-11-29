import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Floor } from '../_models/floor';

@Injectable({
    providedIn: 'root'
})
export class FloorService {
    baseUrl = environment.apiUrl;
    
    constructor(private http: HttpClient) {

    }

    getFloors(): Observable<Floor[]> {
        return this.http.get<Floor[]>(this.baseUrl + 'floors');
    }

    getFloor(id): Observable<Floor> {
        return this.http.get<Floor>(this.baseUrl + 'floors/' + id)
    }
}