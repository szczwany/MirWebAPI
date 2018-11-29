import { Component } from '@angular/core';
import { Floor } from '../../_models/floor';
import { FloorService } from '../../_services/floor.service';

@Component({
    selector: 'app-floor-list',
    templateUrl: './floor-list.component.html',
    styleUrls: ['./floor-list.component.css']
})
export class FloorListComponent {
    floors: Floor[];

    constructor(private floorService: FloorService) {

    }

    ngOnInit(): void {
        this.loadFloors();
    }

    loadFloors() {
        this.floorService.getFloors().subscribe((floors: Floor[]) => {
            this.floors = floors;
        }, error => {
            console.log(error);
        })
    }
}