/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { MapTypeTableComponent } from './map-type-table.component';

let component: MapTypeTableComponent;
let fixture: ComponentFixture<MapTypeTableComponent>;

describe('mapType-table component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ MapTypeTableComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(MapTypeTableComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});