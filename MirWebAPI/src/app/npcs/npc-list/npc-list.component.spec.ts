/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { NpcListComponent } from './npc-list.component';

let component: NpcListComponent;
let fixture: ComponentFixture<NpcListComponent>;

describe('npc-list component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ NpcListComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(NpcListComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});