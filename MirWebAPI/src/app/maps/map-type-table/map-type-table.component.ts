import { Component } from '@angular/core';
import { MapType } from '../../_models/mapType';
import { MapTypeService } from '../../_services/mapType.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-map-type-table',
    templateUrl: './map-type-table.component.html',
    styleUrls: ['./map-type-table.component.css']
})
export class MapTypeTableComponent {
    typeParameter: string;
    types: MapType[];

    constructor(private activatedRoute: ActivatedRoute, private mapTypeService: MapTypeService) {

    }

    ngOnInit(): void {
        this.activatedRoute.queryParams.subscribe((params) => {
            this.typeParameter = params['type'];
        })

        if (this.typeParameter != null) {
            console.log(this.typeParameter);

            this.loadParamsTypes(this.typeParameter);
        } else {
            console.log('dupa');

            this.loadTypes();
        }
    }

    loadTypes() {
        this.mapTypeService.getTypes().subscribe((types: MapType[]) => {
            this.types = types;
        }, error => {
            console.log(error);
        })
    }

    loadParamsTypes(type: string) {
        this.mapTypeService.getParamsTypes(type).subscribe((types: MapType[]) => {
            this.types = types;
        }, error => {
            console.log(error);
        })
    }
}