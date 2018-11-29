import { Component, OnInit } from '@angular/core';
import { Skill } from '../../_models/skill';
import { SkillService } from '../../_services/skill.service';

@Component({
    selector: 'app-skill-list',
    templateUrl: './skill-list.component.html',
    styleUrls: ['./skill-list.component.css']
})
export class SkillListComponent implements OnInit {
    skills: Skill[];

    constructor(private skillService: SkillService) {

    }

    ngOnInit(): void {
        this.loadSkills();
    }

    loadSkills() {
        this.skillService.getSkills().subscribe((skills: Skill[]) => {
            this.skills = skills;
            this.skills.sort((n1, n2) => {
                if (n1.id > n2.id) {
                    return 1;
                }

                if (n1.id < n2.id) {
                    return -1;
                }

                return 0;
            });      
        }, error => {
            console.log(error);
        })
    }
}