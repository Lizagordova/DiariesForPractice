import React, { Component } from "react";
import { MainProps } from "../../models/MainProps";
import { observer } from "mobx-react";
import { Nav, NavItem } from "reactstrap";
import { NavLink, Redirect, Route, Switch } from "react-router-dom";
import { UserRole } from "../../Typings/enums/UserRole";
import InstituteStructurePage from "./InstituteStructurePage/GroupsPage";
import UsersPage from "./UsersPage/UsersPage";
import HomePage from "./HomePage/HomePage";

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
                    <NavLink to="/users" exact className="nav-link"
                             activeStyle={{backgroundColor: "black", color: "white", textDecoration: "none"}}>
                        Пользователи
                    </NavLink>
                </NavItem>}
                <NavItem>
                    <NavLink to="/groups" exact className="nav-link" style={{fontSize: "1.5em"}}
                             activeStyle={{backgroundColor: "black", color: "white", textDecoration: "none"}}>
                        Структура университета
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
                    <Route exact path="/users"
                           render={(props) => <UsersPage userStore={this.props.store.userStore} />} />
                    <Route exact path="/institutestructure"
                           render={(props) => <InstituteStructurePage instituteStore={this.props.store.instituteDetailsStore} />} />
                    <Redirect to="/home" />
                </Switch>
            </>
        );
    }
}

export default AdminMain;