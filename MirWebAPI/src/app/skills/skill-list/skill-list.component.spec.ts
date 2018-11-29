/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { SkillListComponent } from './skill-list.component';

let component: SkillListComponent;
let fixture: ComponentFixture<SkillListComponent>;

describe('skill-list component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ SkillListComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(SkillListComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});