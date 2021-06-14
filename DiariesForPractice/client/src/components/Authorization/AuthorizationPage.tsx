import React, { Component } from "react";
import { RootStore } from "../../stores/RootStore";
import { observer } from "mobx-react";
import LoadingWindow from "./LoadingWindow";
import { Nav, NavItem } from "reactstrap";
import { NavLink } from "react-router-dom";
import { makeObservable, observable } from "mobx";
import RegistrationWindow from "./RegistrationWindow";
import AuthorizationWindow from "./AuthorizationWindow";
import { AuthorizationMode } from "../../consts/AuthorizationMode";

class AuthorizationPageProps {
    store: RootStore;

}

@observer
class AuthorizationPage extends Component<AuthorizationPageProps> {
    authorizationMode: AuthorizationMode = AuthorizationMode.Authorization;
    
    constructor(props: AuthorizationPageProps) {
        super(props);
        makeObservable(this, {
            authorizationMode: observable
        })
    }

    renderOptionTabs() {
        return(
            <>
                <Nav tabs defaultValue={1}>
                    <NavItem>
                        <NavLink
                            to={"#"}
                            onClick={() => this.authorizationModeToggle(AuthorizationMode.Authorization)}
                            className="nav-link"
                            activeClassName="selected"
                        >Вход</NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink
                            to={"#"}
                            onClick={() => this.authorizationModeToggle(AuthorizationMode.Registration)}
                            className="nav-link"
                            activeClassName="selected">Регистрация</NavLink>
                    </NavItem>
                </Nav>
                {this.renderOption()}
            </>
        );
    }
    
    renderOption() {
        return (
            <>
                {this.authorizationMode === AuthorizationMode.Registration && <RegistrationWindow store={this.props.store} modeToggle={this.authorizationModeToggle}/>}
                {this.authorizationMode === AuthorizationMode.Authorization && <AuthorizationWindow store={this.props.store} />}
            </>
        );
    }

    renderAuthorizationWindow() {
        return (
            <div className="row justify-content-center authorizationForm">
                {this.renderOptionTabs()}
                <div className="row justify-content-center">
                    <a href="#">Забыли пароль?</a>
                </div>
            </div>
        );
    }
    
    render() {
        let { checkedToken } = this.props.store.userStore;
        return(
            <>
                {this.renderAuthorizationWindow()}
                {checkedToken && this.renderAuthorizationWindow()}
                {!checkedToken && <LoadingWindow />}
            </>
        );
    }

    authorizationModeToggle(authorizationMode: AuthorizationMode) {
        this.authorizationMode = authorizationMode;
    }
}

export default AuthorizationPage;