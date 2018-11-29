/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { RoleDetailComponent } from './role-detail.component';

let component: RoleDetailComponent;
let fixture: ComponentFixture<RoleDetailComponent>;

describe('role-detail component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ RoleDetailComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(RoleDetailComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});