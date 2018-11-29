import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { HttpClient } from 'selenium-webdriver/http';
import { MapService } from './_services/map.service';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { appRoutes } from './routes';
import { RouteGuard } from './_guards/route.guard';
import { MapListComponent } from './maps/map-list/map-list.component';
import { MapDetailComponent } from './maps/map-detail/map-detail.component';
import { MonsterService } from './_services/monster.service';
import { MonsterListComponent } from './monsters/monster-list/monster-list.component';
import { RoleDetailComponent } from './roles/role-detail/role-detail.component';
import { RoleService } from './_services/role.service';
import { RoleListComponent } from './roles/role-list/role-list.component';
import { FloorListComponent } from './floors/floor-list/floor-list.component';
import { FloorService } from './_services/floor.service';
import { NpcListComponent } from './npcs/npc-list/npc-list.component';
import { NpcService } from './_services/npc.service';
import { MapTypeTableComponent } from './maps/map-type-table/map-type-table.component';
import { MapTypeService } from './_services/mapType.service';
import { SkillListComponent } from './skills/skill-list/skill-list.component';
import { SkillService } from './_services/skill.service';


@NgModule({
  declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      MapListComponent,
      MapDetailComponent,
      MapTypeTableComponent,
      MonsterListComponent,
      RoleDetailComponent,
      RoleListComponent,
      FloorListComponent,
      NpcListComponent,
      SkillListComponent
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      RouterModule.forRoot(appRoutes)
  ],
  providers: [
      MapService,
      MonsterService,
      ErrorInterceptorProvider,
      RouteGuard,
      RoleService,
      FloorService,
      NpcService,
      MapTypeService,
      SkillService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
