import UserStore from "./UserStore";
import { makeObservable, observable } from "mobx";
import InstituteDetailsStore from "./InstituteDetailsStore";
import DiariesStore from "./DiariesStore";
import OrganizationStore from "./OrganizationStore";
import PracticeStore from "./PracticeStore";
import CommentStore from "./CommentStore";
import NotificationStore from "./NotificationStore";

export class RootStore {
    userStore: UserStore;
    instituteDetailsStore: InstituteDetailsStore;
    diariesStore: DiariesStore;
    organizationStore: OrganizationStore;
    practiceStore: PracticeStore;
    commentStore: CommentStore;
    notificationStore: NotificationStore;

    constructor() {
        makeObservable(this, {
            userStore: observable,
            instituteDetailsStore: observable,
            diariesStore: observable,
            organizationStore: observable,
            practiceStore: observable,
            commentStore: observable,
            notificationStore: observable,
        });
        this.setInitialState();
    }

    setInitialState() {
        this.userStore = new UserStore();
        this.instituteDetailsStore = new InstituteDetailsStore();
        this.diariesStore = new DiariesStore();
        this.organizationStore = new OrganizationStore();
        this.practiceStore = new PracticeStore();
        this.commentStore = new CommentStore();
        this.notificationStore = new NotificationStore();
    }

    reset() {
        this.setInitialState();
    }
}