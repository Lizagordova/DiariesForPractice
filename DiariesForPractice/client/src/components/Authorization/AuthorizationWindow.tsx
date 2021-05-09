import React, { Component } from "react";
import { RootStore } from "../../stores/RootStore";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";
import { Input, Button, Alert } from "reactstrap";
import { UserReadModel } from "../../Typings/readModels/UserReadModel";

class AuthorizationWindowProps {
    store: RootStore;
}

@observer
class AuthorizationWindow extends Component<AuthorizationWindowProps> {
    login: string;
    password: string;
    notAuthorized: boolean;
    
    constructor(props: AuthorizationWindowProps) {
        super(props);
        makeObservable(this, {
            login: observable,
            password: observable,
            notAuthorized: observable
        });
    }

    renderWarnings() {
        setTimeout(() => {
            this.notAuthorized = false;
        }, 6000);
        return (
            <Alert>
                Неправильно введён логин или пароль
            </Alert>
        );
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
            <Button
                outline color="secondary"
                onClick={() => this.enter()}>
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
                {this.renderWarnings()}
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

    enter() {
        let user = new UserReadModel();
        user.login = this.login;
        user.password = this.password;
        this.props.store.userStore.authorize(user)
            .then((status) => {
                this.notAuthorized = status !== 200;
            })
    }
}

export default AuthorizationWindow;

enum AuthorizationData {
    Login,
    Password
}