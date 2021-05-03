import React, { Component } from "react";
import { RootStore } from "../../stores/RootStore";
import { observer } from "mobx-react";
import {makeObservable, observable} from "mobx";
import { Input, Button } from "reactstrap";

class AuthorizationWindowProps {
    store: RootStore;
}

@observer
class AuthorizationWindow extends Component<AuthorizationWindowProps> {
    login: string;
    password: string;
    
    constructor(props: AuthorizationWindowProps) {
        super(props);
        makeObservable(this, {
            login: observable,
            password: observable
        })
    }

    renderLoginInput() {
        return (
            <Input
                onChange={(event) => this.authorizationDataInput(event, AuthorizationData.Login)}
                placeholder="Введите логин"
                className="authInput" />
        );
    }
    
    renderPasswordInput() {
        return (
            <Input
                onChange={(event) => this.authorizationDataInput(event, AuthorizationData.Password)}
                placeholder="Введите пароль"
                type="password"
                className="authInput" />
        );
    }

    renderButton() {
        return (
            <Button>
                Войти
            </Button>
        );
    }

    renderAuthorizationWindow() {
        return (
            <>
                {this.renderLoginInput()}
                {this.renderPasswordInput()}
                {this.renderButton()}
            </>
        );
    }

    render() {
        return (
            <div className="container-fluid">
                {this.renderAuthorizationWindow()}
            </div>
        );
    }

    authorizationDataInput(event: React.FormEvent<HTMLInputElement>, authorizationData: AuthorizationData) {
        if(authorizationData === AuthorizationData.Login) {
            this.login = event.currentTarget.value;
        } else if(authorizationData === AuthorizationData.Password) {
            this.password = event.currentTarget.value;
        }
    }
}

export default AuthorizationWindow;

enum AuthorizationData {
    Login,
    Password
}