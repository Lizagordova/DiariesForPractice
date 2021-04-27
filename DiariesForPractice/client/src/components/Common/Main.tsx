import React, { Component } from "react";
import { RootStore } from "../../stores/RootStore";
import { Nav, NavItem } from "reactstrap";
import { NavLink, Switch, Route, Redirect } from "react-router-dom";
import {UserRole} from "../../Typings/enums/UserRole";
import HomePage from "./Home/HomePage";
import SettingsPage from "../Admin/Settings/SettingsPage";

class IMainProps {
    store: RootStore;
}

class Main extends Component<IMainProps> {
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

export default Main;