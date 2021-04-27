import { makeObservable, observable } from "mobx";
import { GoogleDetailsViewModel } from "../Typings/viewModels/GoogleDetailsViewModel";
import {GoogleDetailsReadModel} from "../Typings/readModels/GoogleDetailsReadModel";

class GoogleDetailsStore {
    googleDetails: GoogleDetailsViewModel[] = new Array<GoogleDetailsViewModel>();

    constructor() {
        makeObservable(this, {
            googleDetails: observable
        });
    }
    
    async addOrUpdateGoogleDetails(googleDetails: GoogleDetailsReadModel): Promise<number> {
        const response = await fetch("/addorupdategoogledetails", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                googleDetails//todo: так может не сработать
            })
        });
        
        return 200;
    }

    async getGoogleDetailsByGroup(groupId: number): Promise<GoogleDetailsViewModel> {
        let googleDetails = new GoogleDetailsViewModel();
        const response = await fetch("/getgoogledetailsbygroup", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                groupId: groupId
            })
        });
        if(response.status === 200) {
            googleDetails = await response.json();
        }

        return googleDetails;
    }
}

export default GoogleDetailsStore;