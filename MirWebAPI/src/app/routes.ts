import { Routes } from '@angular/router'
import { HomeComponent } from './home/home.component';
import { RouteGuard } from './_guards/route.guard';
import { MapListComponent } from './maps/map-list/map-list.component';
import { MapDetailComponent } from './maps/map-detail/map-detail.component';
import { MonsterListComponent } from './monsters/monster-list/monster-list.component';
import { RoleDetailComponent } from './roles/role-detail/role-detail.component';
import { RoleListComponent } from './roles/role-list/role-list.component';
import { FloorListComponent } from './floors/floor-list/floor-list.component';
import { NpcListComponent } from './npcs/npc-list/npc-list.component';
import { MapTypeTableComponent } from './maps/map-type-table/map-type-table.component';
import { SkillListComponent } from './skills/skill-list/skill-list.component';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'maps', component: MapListComponent },
    { path: 'maps/:id', component: MapDetailComponent },
    { path: 'types', component: MapTypeTableComponent },
    { path: 'types/find', component: MapTypeTableComponent },
    //{ path: 'types/find/:type', component: MapTypeTableComponent },
    { path: 'monsters', component: MonsterListComponent },
    { path: 'roles', component: RoleListComponent },
    { path: 'roles/:id', component: RoleDetailComponent },
    { path: 'skills', component: SkillListComponent },
    { path: 'skills/:id', component: SkillListComponent },
    { path: 'floors', component: FloorListComponent },
    { path: 'npcs', component: NpcListComponent },
    { path: '**', redirectTo: 'home', pathMatch: 'full' },
];