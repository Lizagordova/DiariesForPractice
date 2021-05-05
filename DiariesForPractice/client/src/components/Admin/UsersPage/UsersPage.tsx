import React, { Component } from "react";
import UserStore from "../../../stores/UserStore";
import { observer } from "mobx-react";
import { Table } from "reactstrap";
import { UserViewModel } from "../../../Typings/viewModels/UserViewModel";
import User from "./User";

class UsersPageProps {
    userStore: UserStore;
}

@observer
class UsersPage extends Component<UsersPageProps> {
    
    constructor(props: UsersPageProps) {
        super(props);
        
    }
    
    renderUsers(users: UserViewModel[]) {
        return (
            <Table>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>ФИО</th>
                        <th>Email</th>
                        <th>Phone</th>
                        <th>Роли</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map((user, index) => {
                        this.renderUser(user)
                    })}
                </tbody>
            </Table>
        );
    }
    
    renderUser(user: UserViewModel) {
        return (
            <User userStore={this.props.userStore} user={user} key={user.id} />
        );
    }
    
    render() {
        let { users } = this.props.userStore;
        return (
            <>
                {this.renderUsers(users)}
            </>
        );
    }
}

export default UsersPage;