import React, { Component } from "react";
import { MainProps } from "../../models/MainProps";
import { observer } from "mobx-react";
import {Nav, NavItem} from "reactstrap";
import {NavLink, Redirect, Route, Switch} from "react-router-dom";
import {UserRole} from "../../Typings/enums/UserRole";
import HomePage from "../Common/Home/HomePage";
import SettingsPage from "./Settings/SettingsPage";

@observer
class AdminMain extends Component<MainProps> {
    constructor(props: MainProps) {
        super(props);
    }

    renderMenu() {
        return (
            <Nav tabs className="nav">
                <NavItem>
                    <NavLink to="/home" exact className="nav-link" style={{fontSize: "1.5em"}}
                             activeStyle={{backgroundColor: "black", color: "white", textDecoration: "none"}}>
                        Главная
                    </NavLink>
                </NavItem>
                {this.props.store.userStore.currentUser.role === UserRole.Admin && <NavItem>
                    <NavLink to="/settings" exact className="nav-link"
                             activeStyle={{backgroundColor: "black", color: "white", textDecoration: "none"}}>
                        Настройки
                    </NavLink>
                </NavItem>}
                <NavItem>
                    <NavLink to="/settings" exact className="nav-link" style={{fontSize: "1.5em"}}
                             activeStyle={{backgroundColor: "black", color: "white", textDecoration: "none"}}>
                        Настройки
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
                    <Route exact path="/settings"
                           render={(props) => <SettingsPage store={this.props.store} />} />
                    <Redirect to="/home" />
                </Switch>
            </>
        );
    }
}

export default AdminMain;