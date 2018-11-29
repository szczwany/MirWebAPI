/// <reference path="../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { MonsterListComponent } from './monster-list.component';

let component: MonsterListComponent;
let fixture: ComponentFixture<MonsterListComponent>;

describe('monster-list component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ MonsterListComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(MonsterListComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});