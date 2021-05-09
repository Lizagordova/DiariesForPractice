import UserStore from "./UserStore";
import { makeObservable, observable } from "mobx";
import GoogleDetailsStore from "./GoogleDetailsStore";
import InstituteDetailsStore from "./InstituteDetailsStore";
import DiariesStore from "./DiariesStore";
import StudentStore from "./StudentStore";
import OrganizationStore from "./OrganizationStore";
import PracticeStore from "./PracticeStore";

export class RootStore {
    userStore: UserStore;
    googleDetailsStore: GoogleDetailsStore;
    instituteDetailsStore: InstituteDetailsStore;
    diariesStore: DiariesStore;
    studentStore: StudentStore;
    organizationStore: OrganizationStore;
    practiceStore: PracticeStore;

    constructor() {
        makeObservable(this, {
            userStore: observable,
            googleDetailsStore: observable,
            instituteDetailsStore: observable,
            diariesStore: observable,
            studentStore: observable,
            organizationStore: observable,
            practiceStore: observable
        });
        this.setInitialState();
    }

    setInitialState() {
        this.userStore = new UserStore();
        this.googleDetailsStore = new GoogleDetailsStore();
        this.instituteDetailsStore = new InstituteDetailsStore();
        this.diariesStore = new DiariesStore();
        this.studentStore = new StudentStore();
        this.organizationStore = new OrganizationStore();
        this.practiceStore = new PracticeStore();
    }
}