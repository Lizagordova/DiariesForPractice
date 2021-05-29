import { makeObservable, observable } from "mobx";

class CommentStore {
    constructor() {
        makeObservable(this, {
        });
    }
}

export default CommentStore;