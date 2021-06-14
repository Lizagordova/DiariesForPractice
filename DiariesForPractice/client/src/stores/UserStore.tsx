import { makeObservable, observable } from "mobx";
import { UserViewModel } from "../Typings/viewModels/UserViewModel";
import { UserReadModel } from "../Typings/readModels/UserReadModel";

class UserStore {
    currentUser: UserViewModel = new UserViewModel();
    checkedToken: boolean = false;
    authorized: boolean = false;
    users: UserViewModel[] = new Array<UserViewModel>();

    constructor() {
        makeObservable(this, {
            currentUser: observable,
            checkedToken: observable,
            authorized: observable,
            users: observable
        });
    }
    
    async authorize(user: UserReadModel): Promise<number> {
        const response = await fetch("/authorize", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                user//todo: опять же - не знаю, сработает ли это
            })
        });
        if(response.status === 200) {
            let userId = await response.json();
            this.getUserById(userId);
        }
        
        return response.status;
    }
    
    async register(user: UserReadModel): Promise<number> {
        const response = await fetch("/register", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                user//todo: опять же - не знаю, сработает ли это
            })
        });
        if(response.status === 200) {
            let userId = await response.json();
            await this.getUserById(userId);
        }
        
        return response.status;
    }
    
    async getUserById(userId: number) {
        const response = await fetch(`getuserbyid?userId=${userId}`);//todo: вспомни как правильно это делается
        if(response.status === 200) {
            this.currentUser = await response.json();
            this.authorized = true;
        }
    }
    
    async addOrUpdateUser(user: UserReadModel): Promise<number> {
        const response = await fetch("/addorupdateuser", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                user//todo: опять же - не знаю, сработает ли это
            })
        });
        if(response.status === 200) {
            this.getUsers();
        }
        
        return response.status;
    }
    
    async getUsers() {
        const response = await fetch("/getusers");
  
        this.users = await response.json();
    }
}

export default UserStore;