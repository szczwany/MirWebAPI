import { Component } from '@angular/core';
import { Role } from '../../_models/role';
import { RoleService } from '../../_services/role.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-role-detail',
    templateUrl: './role-detail.component.html',
    styleUrls: ['./role-detail.component.css']
})

export class RoleDetailComponent {
    role: Role;

    constructor(private roleService: RoleService, private route: ActivatedRoute) {

    }

    ngOnInit() {
        this.loadRole();
    }

    loadRole() {
        this.roleService.getRole(+this.route.snapshot.params['id']).subscribe((role: Role) => {
            this.role = role;
        }, error => {
            console.log(error);
        });
    }
}