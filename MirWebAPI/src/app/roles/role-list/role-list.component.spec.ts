/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { RoleListComponent } from './role-list.component';

let component: RoleListComponent;
let fixture: ComponentFixture<RoleListComponent>;

describe('role-list component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ RoleListComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(RoleListComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});