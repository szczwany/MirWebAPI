import { Component } from '@angular/core';
import { RoleService } from '../../_services/role.service';
import { Role } from '../../_models/role';

@Component({
    selector: 'app-role-list',
    templateUrl: './role-list.component.html',
    styleUrls: ['./role-list.component.css']
})

export class RoleListComponent {
    roles: Role[];

    constructor(private roleService: RoleService) {

    }

    ngOnInit(): void {
        this.loadRoles();
    }

    loadRoles() {
        this.roleService.getRoles().subscribe((roles: Role[]) => {
            this.roles = roles;
        }, error => {
            console.log(error);
        })
    }
}