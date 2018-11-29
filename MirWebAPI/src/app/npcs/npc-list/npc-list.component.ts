import { Component } from '@angular/core';
import { Npc } from '../../_models/npc';
import { NpcService } from '../../_services/npc.service';

@Component({
    selector: 'app-npc-list',
    templateUrl: './npc-list.component.html',
    styleUrls: ['./npc-list.component.css']
})
export class NpcListComponent {
    npcs: Npc[];

    constructor(private npcService: NpcService) {

    }

    ngOnInit(): void {
        this.loadNpcs();
    }

    loadNpcs() {
        this.npcService.getNpcs().subscribe((npcs: Npc[]) => {
            this.npcs = npcs;
        }, error => {
            console.log(error);
        })
    }
}