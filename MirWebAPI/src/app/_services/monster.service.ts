import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Monster } from '../_models/monster';
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class MonsterService {
    baseUrl = environment.apiUrl;
    
    constructor(private http: HttpClient) {

    }

    getMonsters(): Observable<Monster[]> {
        return this.http.get<Monster[]>(this.baseUrl + 'monsters');
    }

    getMonster(id): Observable<Monster> {
        return this.http.get<Monster>(this.baseUrl + 'monsters/' + id)
    }
}