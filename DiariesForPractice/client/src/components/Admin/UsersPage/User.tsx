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
    
    getRolesString(role: UserRole): string {        
        return translateUserRole(role);
    }
    
    renderUser(user: UserViewModel) {
        return (
            <>
                <tr onClick={() => this.toggleAddOrUpdateUserWindow()}>
                    <th>{user.id}</th>
                    <th>{user.firstName} {user.secondName} {user.lastName}</th>
                    <th>{user.email}</th>
                    <th>{user.phone}</th>
                    <th>{this.getRolesString(user.role)}</th>
                    <th>
                        <i style={{marginLeft: '45%', width: '2%'}}
                           onClick={() => this.removeUser(user.id)}
                           className="fa fa-window-close fa-2x" aria-hidden="true"/>
                    </th>
                </tr>
                
            </>
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

    toggleAddOrUpdateUserWindow = () => {
        this.addOrUpdateWindowOpen = !this.addOrUpdateWindowOpen;
    }

    removeUser(userId: number) {
        this.props.userStore.removeUser(userId)
    }
}

export default User;