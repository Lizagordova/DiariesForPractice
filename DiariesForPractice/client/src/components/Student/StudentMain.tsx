import React, { Component } from "react";
import { MainProps } from "../../models/MainProps";
import { observer } from "mobx-react";
import { Nav, NavItem } from "reactstrap";
import { NavLink, Redirect, Route, Switch } from "react-router-dom";
import HomePage from "./HomePage/HomePage";

@observer
class StudentMain extends Component<MainProps> {
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
                   <Redirect to="/home" />
                </Switch>
            </>
        );
    }
}

export default StudentMain;