import React, { Component } from "react";
import { MainProps } from "../../models/MainProps";
import { observer } from "mobx-react";
import { Nav, NavItem } from "reactstrap";
import { NavLink, Redirect, Route, Switch } from "react-router-dom";
import HomePage from "./HomePage/HomePage";
import UserProfile from "../Common/UserProfile";

@observer
class StudentMain extends Component<MainProps> {
    constructor(props: MainProps) {
        super(props);
    }

    renderMenu() {
        return (
            <Nav tabs className="nav">
                <NavItem>
                    <NavLink
                        to="/home"
                        exact className="nav-link" 
                        style={{fontSize: "1.5em"}}
                        activeStyle={{backgroundColor: "black", color: "white", textDecoration: "none"}}>
                        Главная
                    </NavLink>
                </NavItem>
                <i className="fas fa-bell" />
                <NavItem>
                    <NavLink
                        to="/userprofile"
                        exact className="nav-link"
                        style={{fontSize: "1.5em"}}
                        activeStyle={{backgroundColor: "black", color: "white", textDecoration: "none"}}>
                        <i className="fas fa-user" />
                    </NavLink>
                </NavItem>
            </Nav>
        );
    }

    render() {
        return (
            <>
                {this.renderMenu()}
                <Switch>
                    <Route exact path="/home"
                           render={(props) => <HomePage store={this.props.store} />} />
                    <Route exact path="/userprofile"
                           render={(props) => <UserProfile store={this.props.store} />} />
                   <Redirect to="/home" />
                </Switch>
            </>
        );
    }
}

export default StudentMain;