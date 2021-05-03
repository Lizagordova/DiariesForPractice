import React, { Component } from "react";
import { RootStore } from "../../stores/RootStore";
import { observer } from "mobx-react";
import LoadingWindow from "./LoadingWindow";
import { Nav, NavItem } from "reactstrap";
import { NavLink } from "react-router-dom";
import { makeObservable, observable } from "mobx";
import RegistrationWindow from "./RegistrationWindow";
import AuthorizationWindow from "./AuthorizationWindow";

class AuthorizationPageProps {
    store: RootStore;

}

@observer
class AuthorizationPage extends Component<AuthorizationPageProps> {
    authorizationMode: AuthorizationMode;
    
    constructor(props: AuthorizationPageProps) {
        super(props);
        makeObservable(this, {
            authorizationMode: observable
        })
    }

    renderOptionTabs() {
        return(
            <div className="row justify-content-center">
                <Nav tabs defaultValue={1}>
                    <NavItem>
                        <NavLink to={"#"}
                                 style={{color: 'white'}}
                                 onClick={() => this.authorizationModeToggle(AuthorizationMode.Authorization)}
                                 className="nav-link"
                                 activeClassName="selected"
                        >Вход</NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink to={"#"}
                                 style={{color: 'white'}}
                                 onClick={() => this.authorizationModeToggle(AuthorizationMode.Registration)}
                                 className="nav-link"
                                 activeClassName="selected">Регистрация</NavLink>
                    </NavItem>
                </Nav>
                {this.renderOption()}
            </div>
        );
    }
    
    renderOption() {
        return (
            <>
                {this.authorizationMode === AuthorizationMode.Registration && <RegistrationWindow store={this.props.store} />}
                {this.authorizationMode === AuthorizationMode.Authorization && <AuthorizationWindow store={this.props.store} />}
            </>
        );
    }

    renderAuthorizationWindow() {
        return (
            <>
                {this.renderOptionTabs()}
                <div className="row justify-content-center">
                    <a href="#">Забыли пароль?</a>
                </div>
            </>
        );
    }
    
    render() {
        return(
            <>
                {this.props.store.userStore.checkedToken && this.renderAuthorizationWindow()}
                {!this.props.store.userStore.checkedToken && <LoadingWindow />}
            </>
        );
    }

    authorizationModeToggle(authorizationMode: AuthorizationMode) {
        this.authorizationMode = authorizationMode;
    }
}

export default AuthorizationPage;

enum AuthorizationMode {
    Registration,
    Authorization
}