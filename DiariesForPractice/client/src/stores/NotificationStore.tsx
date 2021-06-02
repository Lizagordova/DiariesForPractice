import { UserNotificationViewModel } from "../Typings/viewModels/UserNotificationViewModel";
import { makeObservable, observable } from "mobx";

class NotificationStore {
    userNotifications: UserNotificationViewModel[] = new Array<UserNotificationViewModel>();
    
    constructor() {
        makeObservable(this, {
            userNotifications: observable
        });
    }
    
    async getUserNotifications(userForId: number, watched: boolean | null): Promise<number> {
        const response = await fetch("/getusernotifications", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                userForId: userForId, watched: watched
            })
        });
        if(response.status === 200) {
            this.userNotifications = await response.json();
        }
        
        return response.status;
    }

    async addOrUpdateUserNotification(userNotification: UserNotificationViewModel): Promise<number> {
        const response = await fetch("/addorupdateusernotification", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                userNotification//todo: хз можно ли так.....
            })
        });

        return response.status;
    }
}

export default NotificationStore;