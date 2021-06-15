﻿import React, { Component } from "react";
import { MainProps } from "../../models/MainProps";
import { observer } from "mobx-react";
import { Nav, NavItem, Button } from "reactstrap";
import { NavLink, Redirect, Route, Switch } from "react-router-dom";
import UsersPage from "./UsersPage/UsersPage";
import HomePage from "./HomePage/HomePage";
import InstituteStructurePage from "./InstituteStructurePage/InstituteStructurePage";

@observer
class AdminMain extends Component<MainProps> {
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
                <NavItem>
                    <NavLink 
                        to="/users" 
                        exact className="nav-link"
                        activeStyle={{backgroundColor: "black", color: "white", textDecoration: "none"}}>
                        Пользователи
                    </NavLink>
                </NavItem>
                <NavItem>
                    <NavLink 
                        to="/institutestructure" 
                        exact className="nav-link"
                        style={{fontSize: "1.5em"}}
                        activeStyle={{backgroundColor: "black", color: "white", textDecoration: "none"}}>
                        Структура университета
                    </NavLink>
                </NavItem>
                <NavItem>
                    <NavLink
                        to="/userprofile"
                        exact className="nav-link"
                        style={{fontSize: "1.5em"}}
                        activeStyle={{backgroundColor: "black", color: "white", textDecoration: "none"}}>
                        <i className="fa fa-user fa-2x" />
                    </NavLink>
                </NavItem>
                <Button
                    className="nav-link exit"
                    outline color="primary"
                    onClick={() => this.exit()}>
                    Выйти
                </Button>
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

    async exit() {
        this.props.store.reset();
    }
}

export default AdminMain;