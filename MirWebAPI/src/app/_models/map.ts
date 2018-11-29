import { Monster } from "./monster";
import { Floor } from "./floor";
import { Npc } from "./npc";

export interface Map {  
    id: number;
    name: string;
    nameKR: string;
    description: string;
    lastUpdate: Date;
    monsters?: Monster[];
    floors: Floor[];
    npcs?: Npc[];
}
