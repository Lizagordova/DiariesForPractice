import React, { Component } from "react";
import UserStore from "../../../stores/UserStore";
import { UserViewModel } from "../../../Typings/viewModels/UserViewModel";
import { observer } from "mobx-react";
import { UserRole } from "../../../Typings/enums/UserRole";
import { translateUserRole } from "../../../functions/translater";
import { makeObservable, observable } from "mobx";
import AddOrUpdateUserWindow from "./AddOrUpdateUserWindow";

class IUserProps {
    userStore: UserStore;
    user: UserViewModel;
}

@observer
class User extends Component<IUserProps> {
    addOrUpdateWindowOpen: boolean;

    constructor(props: IUserProps) {
        super(props);
        makeObservable(this, {
            addOrUpdateWindowOpen: observable
        });
    }
    
    getRolesString(roles: UserRole[]): string {
        let roleString = "";
        {roles.map(role => {
            roleString += `${translateUserRole(role)}; `;
        })}
        
        return roleString;
    }
    
    renderUser(user: UserViewModel) {
        return (
            <tr onClick={() => this.toggleAddOrUpdateUserWindow()}>
                <th>{user.id}</th>
                <th>{user.firstName} {user.secondName} {user.lastName}</th>
                <th>{user.email}</th>
                <th>{user.phone}</th>
                <th>{this.getRolesString(user.roles)}</th>
            </tr>
        );
    }
    
    render() {
        let { user, userStore } = this.props;
        return (
            <>
                {this.renderUser(user)}
                {this.addOrUpdateWindowOpen && <AddOrUpdateUserWindow toggle={this.toggleAddOrUpdateUserWindow} user={user} userStore={userStore} />}
            </>
        );
    }

    toggleAddOrUpdateUserWindow() {
        this.addOrUpdateWindowOpen = !this.addOrUpdateWindowOpen;
    }
}

export default User;