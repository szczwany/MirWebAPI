import { Component, OnInit } from '@angular/core';
import { Map } from '../../_models/map';
import { MapService } from '../../_services/map.service';

@Component({
    selector: 'app-map-list',
    templateUrl: './map-list.component.html',
    styleUrls: ['./map-list.component.css']
})
export class MapListComponent implements OnInit {
    maps: Map[];

    constructor(private mapService: MapService) {

    }

    ngOnInit(): void {
        this.loadMaps();
    }

    loadMaps() {
        this.mapService.getMaps().subscribe((maps: Map[]) => {
            this.maps = maps;
        }, error => {
            console.log(error);
        })
    }
}