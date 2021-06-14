import React, { Component } from "react";
import { RootStore } from "../../stores/RootStore";
import { observer } from "mobx-react";
import {makeObservable, observable} from "mobx";
import {UserReadModel} from "../../Typings/readModels/UserReadModel";
import {Alert, Button, Input, Label} from "reactstrap";
import {mapUserReadModel} from "../../functions/mapper";
import {AuthorizationMode} from "../../consts/AuthorizationMode";

class RegistrationWindowProps {
    store: RootStore;
    modeToggle: any;
}

@observer
class RegistrationWindow extends Component<RegistrationWindowProps> {
    user: UserReadModel = new UserReadModel();
    notRegistered: boolean;
    
    constructor(props: RegistrationWindowProps) {
        super(props);
        makeObservable(this, {
          user: observable,
            notRegistered: observable
        });
    }

    renderWarnings() {
        setTimeout(() => {
            this.notRegistered = false;
        }, 10000);
        return (
            <>
                {this.notRegistered && <Alert>
                    Что-то пошло не так и не удалось зарегистироваться
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
                    onChange={(event) => this.registrationDataInput(event, RegistrationData.Login)}
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
                    onChange={(event) => this.registrationDataInput(event, RegistrationData.Password)}
                    placeholder="Введите пароль"
                    type="password"
                    className="authInput" />
            </div>
        );
    }

    renderFirstNameInput() {
        return (
            <div className="row justify-content-center dataBlock">
                <Label className="dataLabel">
                    Имя
                </Label>
                <Input
                    onChange={(event) => this.registrationDataInput(event, RegistrationData.FirstName)}
                    placeholder="Введите имя"
                    className="authInput" />
            </div>
        );
    }

    renderSecondNameInput() {
        return (
            <div className="row justify-content-center dataBlock">
                <Label className="dataLabel">
                    Отчество
                </Label>
                <Input
                    onChange={(event) => this.registrationDataInput(event, RegistrationData.SecondName)}
                    placeholder="Введите отчество"
                    className="authInput" />
            </div>
        );
    }

    renderPhoneInput() {
        return (
            <div className="row justify-content-center dataBlock">
                <Label className="dataLabel">
                    Телефон
                </Label>
                <Input
                    onChange={(event) => this.registrationDataInput(event, RegistrationData.Phone)}
                    placeholder="Введите телефон"
                    className="authInput" />
            </div>
        );
    }

    renderEmailInput() {
        return (
            <div className="row justify-content-center dataBlock">
                <Label className="dataLabel">
                    Email
                </Label>
                <Input
                    onChange={(event) => this.registrationDataInput(event, RegistrationData.Email)}
                    placeholder="Введите email"
                    className="authInput" />
            </div>
        );
    }

    renderLastNameInput() {
        return (
            <div className="row justify-content-center dataBlock">
                <Label className="dataLabel">
                    Фамилия
                </Label>
                <Input
                    onChange={(event) => this.registrationDataInput(event, RegistrationData.LastName)}
                    placeholder="Введите фамилию"
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
                    onClick={() => this.register()}>
                    Войти
                </Button>
            </div>
        );
    }
    
    renderRegistrationWindow() {
        return (
            <div className="container-fluid">
                {this.renderLoginInput()}
                {this.renderEmailInput()}
                {this.renderFirstNameInput()}
                {this.renderSecondNameInput()}
                {this.renderLastNameInput()}
                {this.renderPasswordInput()}
                {this.renderPhoneInput()}
                {this.renderButton()}
            </div>
        );
    }
    
    render() {
        return (
            <div className="container-fluid">
                <div className="row justify-content-center">
                    {this.renderWarnings()}
                    {this.renderRegistrationWindow()}
                </div>
            </div>
        );
    }

    registrationDataInput(event: React.FormEvent<HTMLInputElement>, registrationData: RegistrationData) {
        if(registrationData === RegistrationData.Login) {
            this.user.login = event.currentTarget.value;
        } else if(registrationData === RegistrationData.Password) {
            this.user.password = event.currentTarget.value;
        } else if(registrationData === RegistrationData.Email) {
            this.user.email = event.currentTarget.value;
        } else if(registrationData === RegistrationData.FirstName) {
            this.user.firstName = event.currentTarget.value;
        } else if(registrationData === RegistrationData.LastName) {
            this.user.lastName = event.currentTarget.value;
        } else if(registrationData === RegistrationData.SecondName) {
            this.user.secondName = event.currentTarget.value;
        } else if(registrationData === RegistrationData.Phone) {
            this.user.phone = event.currentTarget.value;
        }
    }

    register() {
        this.props.store.userStore.register(this.user)
            .then((status) => {
                if(status === 200) {
                    this.props.modeToggle(AuthorizationMode.Authorization);
                } else {
                    this.notRegistered = true;
                }
            });
    }
}

export default RegistrationWindow;

enum RegistrationData {
    Login,
    Password,
    FirstName,
    SecondName,
    LastName,
    Email,
    Phone
}