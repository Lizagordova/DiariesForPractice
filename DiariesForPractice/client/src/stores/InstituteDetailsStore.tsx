import { makeObservable, observable } from "mobx";
import { DegreeViewModel } from "../Typings/viewModels/DegreeViewModel";
import { CourseViewModel } from "../Typings/viewModels/CourseViewModel";
import { InstituteViewModel } from "../Typings/viewModels/InstituteViewModel";
import { GroupViewModel } from "../Typings/viewModels/GroupViewModel";
import { CafedraViewModel } from "../Typings/viewModels/CafedraViewModel";
import { DirectionViewModel } from "../Typings/viewModels/DirectionViewModel";
import {InstituteReadModel} from "../Typings/readModels/InstituteReadModel";
import {UserViewModel} from "../Typings/viewModels/UserViewModel";
import {GroupReadModel} from "../Typings/readModels/GroupReadModel";

class InstituteDetailsStore {
    degrees: DegreeViewModel[] = new Array<DegreeViewModel>();
    courses: CourseViewModel[] = new Array<CourseViewModel>();
    groups: GroupViewModel[] = new Array<GroupViewModel>();
    institutes: InstituteViewModel[] = new Array<InstituteViewModel>();
    cafedras: CafedraViewModel[] = new Array<CafedraViewModel>();
    directions: DirectionViewModel[] = new Array<DirectionViewModel>();

    constructor() {
        makeObservable(this, {
            degrees: observable,
            courses: observable,
            groups: observable,
            institutes: observable,
            cafedras: observable,
            directions: observable,
        });
        this.setInitialData();
    }

    setInitialData() {
        this.getInstituteData();
    }

    async getInstituteData() {
        const response = await fetch("/getinstitutedata");
        /*if(response.status === 200) {
            let data = response.json();
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
        }*/
    }
    
    async addOrUpdateInstitute(institute: InstituteReadModel): Promise<number> {
        return 200;
    }

    async addOrUpdateGroup(group: GroupReadModel): Promise<number> {
        return 200;
    }
}

export default InstituteDetailsStore;