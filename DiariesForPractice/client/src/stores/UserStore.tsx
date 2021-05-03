﻿import { makeObservable, observable } from "mobx";
import { UserViewModel } from "../Typings/viewModels/UserViewModel";

class UserStore {
    currentUser: UserViewModel = new UserViewModel();
    checkedToken: boolean;

    constructor() {
        makeObservable(this, {
            currentUser: observable
        });
    }
}

export default UserStore;