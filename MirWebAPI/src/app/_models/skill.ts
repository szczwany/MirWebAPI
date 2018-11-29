import { Role } from "./role";

export interface Skill {
    id: number;
    name: string;
    nameKR: string;
    iconUrl: string;
    type: string;
    consumption: string;
    training: string;
    explanation: string;
    skillUrl: string;

    role: Role;
}
