import { makeObservable, observable } from "mobx";
import { DegreeViewModel } from "../Typings/viewModels/DegreeViewModel";
import { CourseViewModel } from "../Typings/viewModels/CourseViewModel";
import { InstituteViewModel } from "../Typings/viewModels/InstituteViewModel";
import { GroupViewModel } from "../Typings/viewModels/GroupViewModel";
import { CafedraViewModel } from "../Typings/viewModels/CafedraViewModel";
import { DirectionViewModel } from "../Typings/viewModels/DirectionViewModel";
import {InstituteReadModel} from "../Typings/readModels/InstituteReadModel";
import {GroupReadModel} from "../Typings/readModels/GroupReadModel";
import {CafedraReadModel} from "../Typings/readModels/CafedraReadModel";
import {DirectionReadModel} from "../Typings/readModels/DirectionReadModel";
import {CourseReadModel} from "../Typings/readModels/CourseReadModel";
import {DegreeReadModel} from "../Typings/readModels/DegreeReadModel";
import {UserViewModel} from "../Typings/viewModels/UserViewModel";

class InstituteDetailsStore {
    degrees: DegreeViewModel[] = new Array<DegreeViewModel>();
    courses: CourseViewModel[] = new Array<CourseViewModel>();
    groups: GroupViewModel[] = new Array<GroupViewModel>();
    institutes: InstituteViewModel[] = new Array<InstituteViewModel>();
    cafedras: CafedraViewModel[] = new Array<CafedraViewModel>();
    directions: DirectionViewModel[] = new Array<DirectionViewModel>();
    students: UserViewModel[] = new Array<UserViewModel>();

    constructor() {
        makeObservable(this, {
            degrees: observable,
            courses: observable,
            groups: observable,
            institutes: observable,
            cafedras: observable,
            directions: observable,
            students: observable,
        });
        this.setInitialData();
    }

    setInitialData() {
        this.getInstituteData();
        this.getStudents();
    }

    async getInstituteData() {
        const response = await fetch("/getinstitutedata");
        if(response.status === 200) {
            let data = await response.json();
            // @ts-ignore
            this.institutes = data.institutes;
            // @ts-ignore
            this.courses = data.courses;
            // @ts-ignore
            this.degrees = data.degrees;
            // @ts-ignore
            this.directions = data.directions;
            // @ts-ignore
            this.cafedras = data.cafedras;
            // @ts-ignore
            this.groups = data.groups;
        }
    }
    
    async addOrUpdateInstitute(institute: InstituteReadModel): Promise<number> {
        const response = await fetch("/addorupdateinstitute", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                institute //todo: хз можно ли так
            })
        });
        let id = 0;
        if(response.status === 200) {
            id = await response.json();
        }
        
        return id;
    }

    async addOrUpdateGroup(group: GroupReadModel): Promise<number> {
        const response = await fetch("/addorupdategroup", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                group //todo: хз можно ли так
            })
        });
        let id = 0;
        if(response.status === 200) {
            id = await response.json();
        }

        return id;
    }

    async addOrUpdateCafedra(cafedra: CafedraReadModel): Promise<number> {
        const response = await fetch("/addorupdatecafedra", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                cafedra //todo: хз можно ли так
            })
        });
        let id = 0;
        if(response.status === 200) {
            id = await response.json();
        }

        return id;
    }

    async addOrUpdateDirection(direction: DirectionReadModel): Promise<number> {
        const response = await fetch("/addorupdatedirection", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                direction //todo: хз можно ли так
            })
        });
        let id = 0;
        if(response.status === 200) {
            id = await response.json();
        }

        return id;
    }

    async addOrUpdateCourse(course: CourseReadModel): Promise<number> {
        const response = await fetch("/addorupdatecourse", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                course //todo: хз можно ли так
            })
        });
        let id = 0;
        if(response.status === 200) {
            id = await response.json();
        }

        return id;
    }

    async addOrUpdateDegree(degree: DegreeReadModel): Promise<number> {
        const response = await fetch("/addorupdatedegree", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                degree //todo: хз можно ли так
            })
        });
        let id = 0;
        if(response.status === 200) {
            id = await response.json();
        }

        return id;
    }

    async attachStudentToGroup(studentId: number, groupId: number): Promise<number> {
        const response = await fetch("/attachstudenttogroup", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                studentId: studentId,
                groupId: groupId
            })
        });
        let id = 0;
        if(response.status === 200) {
            id = await response.json();
        }

        return id;
    }

    async removeStudentFromGroup(studentId: number, groupId: number): Promise<number> {
        const response = await fetch("/removestudentfromgroup", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                studentId: studentId,
                groupId: groupId
            })
        });
        let id = 0;
        if(response.status === 200) {
            id = await response.json();
        }

        return id;
    }

    async getStudents() {
        const response = await fetch("/getstudents");
        if(response.status === 200) {
            this.students = await response.json();
        }
    }

    async getGroup(groupId: number): Promise<GroupViewModel> {
        const response = await fetch("/getgroup", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                id: groupId
            })
        });
        let group = new GroupViewModel();
        if(response.status === 200) {
            group = await response.json();
        }
        
        return group;
    }
}

export default InstituteDetailsStore;