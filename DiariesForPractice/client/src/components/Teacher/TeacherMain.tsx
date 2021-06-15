import React, { Component } from "react";
import { MainProps } from "../../models/MainProps";
import { observer } from "mobx-react";
import {Button, Nav, NavItem} from "reactstrap";
import { NavLink, Redirect, Route, Switch } from "react-router-dom";
import HomePage from "./Home/HomePage";
import GroupsPage from "./Groups/GroupsPage";

@observer
class TeacherMain extends Component<MainProps> {
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
                        to="/groups"
                        exact className="nav-link"
                        style={{fontSize: "1.5em"}}
                        activeStyle={{backgroundColor: "black", color: "white", textDecoration: "none"}}>
                        Группы
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
                    <Route exact path="/groups"
                           render={(props) => <GroupsPage store={this.props.store} />} />
                    <Redirect to="/home" />
                </Switch>
            </>
        );
    }

    async exit() {
        this.props.store.reset();
    }
}

export default TeacherMain;