import { Map } from './map';

export interface MapType {
    id: number;
    levelRange: string;
    description: string;
    descriptionKR: string;
    maps: Map[];    
}
