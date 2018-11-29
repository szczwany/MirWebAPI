import { Component, OnInit } from '@angular/core';
import { Map } from '../../_models/map';
import { MapService } from '../../_services/map.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: './app-map-detail',
    templateUrl: './map-detail.component.html',
    styleUrls: ['./map-detail.component.css']
})
export class MapDetailComponent implements OnInit {
    map: Map;

    constructor(private mapService: MapService, private route: ActivatedRoute) {

    }

    ngOnInit() {
        this.loadMap();
    }

    loadMap() {
        this.mapService.getMap(+this.route.snapshot.params['id']).subscribe((map: Map) => {
            this.map = map;
        }, error => {
            console.log(error);
        });
    }
}