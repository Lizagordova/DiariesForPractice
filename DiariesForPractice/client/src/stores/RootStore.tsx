import UserStore from "./UserStore";
import { makeObservable, observable } from "mobx";
import GoogleDetailsStore from "./GoogleDetailsStore";
import InstituteDetailsStore from "./InstituteDetailsStore";
import DiariesStore from "./DiariesStore";
import StudentStore from "./StudentStore";

export class RootStore {
    userStore: UserStore;
    googleDetailsStore: GoogleDetailsStore;
    instituteDetailsStore: InstituteDetailsStore;
    diariesStore: DiariesStore;
    studentStore: StudentStore;

    constructor() {
        makeObservable(this, {
            userStore: observable,
            googleDetailsStore: observable,
            instituteDetailsStore: observable,
            diariesStore: observable,
            studentStore: observable,
        });
        this.setInitialState();
    }

    setInitialState() {
        this.userStore = new UserStore();
        this.googleDetailsStore = new GoogleDetailsStore();
        this.instituteDetailsStore = new InstituteDetailsStore();
        this.diariesStore = new DiariesStore();
        this.studentStore = new StudentStore();
    }
}