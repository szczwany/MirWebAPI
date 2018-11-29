/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { FloorListComponent } from './floor-list.component';

let component: FloorListComponent;
let fixture: ComponentFixture<FloorListComponent>;

describe('floor-list component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ FloorListComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(FloorListComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});