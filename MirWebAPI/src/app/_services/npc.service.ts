import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Npc } from '../_models/npc';

@Injectable({
    providedIn: 'root'
})
export class NpcService {
    baseUrl = environment.apiUrl;
    
    constructor(private http: HttpClient) {

    }

    getNpcs(): Observable<Npc[]> {
        return this.http.get<Npc[]>(this.baseUrl + 'npcs');
    }

    getNpc(id): Observable<Npc> {
        return this.http.get<Npc>(this.baseUrl + 'npcs/' + id)
    }
}