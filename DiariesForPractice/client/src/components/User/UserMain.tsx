import React, { Component } from "react";
import { MainProps } from "../../models/MainProps";
import { observer } from "mobx-react";
import { Nav, NavItem } from "reactstrap";
import { NavLink, Redirect, Route, Switch } from "react-router-dom";

@observer
class UserMain extends Component<MainProps> {
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
            </Nav>
        );
    }

    render() {
        return (
            <>
                {this.renderMenu()}
                <Switch>
                    <Redirect to="/home" />
                </Switch>
            </>
        );
    }
}

export default UserMain;