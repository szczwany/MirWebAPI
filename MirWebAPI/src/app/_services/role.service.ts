import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Role } from '../_models/role';

@Injectable({
    providedIn: 'root'
})
export class RoleService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) {

    }

    getRoles(): Observable<Role[]> {
        return this.http.get<Role[]>(this.baseUrl + 'roles');
    }

    getRole(id): Observable<Role> {
        return this.http.get<Role>(this.baseUrl + 'roles/' + id)
    }
}