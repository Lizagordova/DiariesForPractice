import React, { Component } from "react";
import UserStore from "../../../stores/UserStore";

class UsersPageProps {
    userStore: UserStore;
}

class UsersPage extends Component<UsersPageProps> {
    constructor(props: UsersPageProps) {
        super(props);
    }
    
    render() {
        return (
            <></>
        );
    }
}

export default UsersPage;