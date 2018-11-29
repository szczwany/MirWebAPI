import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Skill } from '../_models/skill';

@Injectable({
    providedIn: 'root'
})
export class SkillService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) {

    }

    getSkills(): Observable<Skill[]> {
        return this.http.get<Skill[]>(this.baseUrl + 'skills');
    }

    getSkill(id): Observable<Skill> {
        return this.http.get<Skill>(this.baseUrl + 'skills/' + id)
    }
}