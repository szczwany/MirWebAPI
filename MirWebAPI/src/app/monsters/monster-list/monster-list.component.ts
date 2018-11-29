import { Component, OnInit } from '@angular/core';
import { MonsterService } from '../../_services/monster.service';
import { Monster } from '../../_models/monster';

@Component({
    selector: 'app-monster-list',
    templateUrl: './monster-list.component.html',
    styleUrls: ['./monster-list.component.css']
})
export class MonsterListComponent implements OnInit {
    monsters: Monster[];

    constructor(private monsterService: MonsterService) {

    }

    ngOnInit(): void {
        this.loadMaps();
    }

    loadMaps() {
        this.monsterService.getMonsters().subscribe((monsters: Monster[]) => {
            this.monsters = monsters;
        }, error => {
            console.log(error);
        })
    }
}