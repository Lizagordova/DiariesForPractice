import React, { Component } from "react";
import { RootStore } from "../../stores/RootStore";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";
import { Input, Button, Alert, Label } from "reactstrap";
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
            <>
                {this.notAuthorized && <Alert>
                    Неправильно введён логин или пароль
                </Alert>}
            </>
        );
    }
    
    renderLoginInput() {
        return (
            <div className="row justify-content-center dataBlock">
                <Label className="dataLabel">
                    Логин
                </Label>
                <Input
                    onChange={(event) => this.authorizationDataInput(event, AuthorizationData.Login)}
                    placeholder="Введите логин"
                    className="authInput" />
            </div>
        );
    }
    
    renderPasswordInput() {
        return (
            <div className="row justify-content-center dataBlock">
                <Label className="dataLabel">
                    Пароль
                </Label>
                <Input
                    onChange={(event) => this.authorizationDataInput(event, AuthorizationData.Password)}
                    placeholder="Введите пароль"
                    type="password"
                    className="authInput" />
            </div>
        );
    }

    renderButton() {
        return (
            <div className="row justify-content-center">
                <Button
                    className="authButton"
                    outline color="secondary"
                    onClick={() => this.enter()}>
                    Войти
                </Button>
            </div>
        );
    }

    renderAuthorizationWindow() {
        return (
            <div className="container-fluid">
                {this.renderLoginInput()}
                {this.renderPasswordInput()}
                {this.renderButton()}
            </div>
        );
    }

    render() {
        return (
            <div className="container-fluid">
                <div className="row justify-content-center">
                {this.renderWarnings()}
                {this.renderAuthorizationWindow()}
                </div>
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
            });
    }
}

export default AuthorizationWindow;

enum AuthorizationData {
    Login,
    Password
}