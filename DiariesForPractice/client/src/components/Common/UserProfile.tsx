import React, { Component } from "react";
import { observer } from "mobx-react";
import { RootStore } from "../../stores/RootStore";
import { UserViewModel } from "../../Typings/viewModels/UserViewModel";
import { makeObservable, observable } from "mobx";
import { Label, Input, Button, Alert } from "reactstrap";
import { mapUserReadModel } from "../../functions/mapper";
import AdditionalInformation from "./AdditionalInformation";

class IUserProfileProps {
    store: RootStore;
}

@observer
class UserProfile extends Component<IUserProfileProps>  {
    user: UserViewModel = new UserViewModel();
    edit: boolean;
    saved: boolean;
    notSaved: boolean;
    
    constructor(props: IUserProfileProps) {
        super(props);
        makeObservable(this, {
            user: observable,
            edit: observable,
            saved: observable,
            notSaved: observable
        });
        this.user = this.props.store.userStore.currentUser;
    }
    
    renderWarnings() {
        setTimeout(() => {
            this.saved = false;
            this.notSaved = false;
        });
        return(
            <>
                {this.saved && <Alert color="success">Данные обновились успешно!</Alert>}
                {this.notSaved && <Alert color="danged">Что-то пошло не так, и данные не сохранились</Alert>}
            </>
        );
    }
    
    renderPersonalInformationLabel() {
        return(
            <div className="row justify-content-center">
                Персональная информация
            </div>
        );
    }

    renderAdditionalInformation() {
        let { store } = this.props;
        return(
            <AdditionalInformation store={store} />
        );
    }
    
    renderFIO(fio: string) {
        return (
            <div className="row justify-content-center">
                <div className="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <Label>
                        ФИО:
                    </Label>
                </div>
                <div className="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    {!this.edit && <span>{fio}</span>}
                    {this.edit && <Input
                        onChange={(e) => this.editUserData(e, UserDataType.FIO)}
                        value={fio}
                    />}
                </div>
            </div>
        );
    }
    
    renderEmail(email: string) {
        return(
            <div className="row justify-content-center">
                <div className="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <Label>
                        Email:
                    </Label>
                </div>
                <div className="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    {!this.edit && <span>{email}</span>}
                    {this.edit && <Input
                        onChange={(e) => this.editUserData(e, UserDataType.Email)}
                        value={`${email}`}
                    />}
                </div>
            </div>
        );
    }
    
    renderPhone(phone: string) {
        return(
            <div className="row justify-content-center">
                <div className="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <Label>
                        Телефон:
                    </Label>
                </div>
                <div className="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    {!this.edit && <span>{phone}</span>}
                    {this.edit && <Input
                        onChange={(e) => this.editUserData(e, UserDataType.Phone)}
                        value={phone}
                        />}
                </div>
            </div>
        );
    }
    
    renderInformation() {
        return(
            <>
                {this.renderFIO(`${this.user.fio}`)}
                {this.renderEmail(this.user.email)}
                {this.renderPhone(this.user.phone)}
            </>
        );
    }

    renderButton() {
        if(this.edit) {
            return (
                <div className="row justify-content-center">
                    <Button
                        color="primary"
                        onClick={() => this.save()}>
                        Сохранить
                    </Button>
                </div>
            );
        } else {
            return (
                <div className="row justify-content-center">
                    <Button
                        color="primary"
                        onClick={() => this.toggleEdit()}>
                        Редактировать
                        <i className="fa fa-edit fa-2x" />
                    </Button>
                </div>
            );
        }
    }
    
    render() {
        return(
            <>
                {this.renderWarnings()}
                {this.renderPersonalInformationLabel()}
                {this.renderInformation()}
                {this.renderButton()}
                {this.renderAdditionalInformation()}
            </>
        );
    }

    editUserData(event: React.ChangeEvent<HTMLInputElement>, type: UserDataType) {
        let value = event.currentTarget.value;
        if(type === UserDataType.FIO) {
            this.user.firstName = value;
        } else if(type === UserDataType.Email) {
            this.user.email = value;
        } else if(type === UserDataType.Phone) {
            this.user.phone = value;
        }
    }

    toggleEdit() {
        this.edit = !this.edit;
    }

    save() {
        let user = mapUserReadModel(this.user);
        this.props.store.userStore.addOrUpdateUser(user)
            .then((status) => {
                this.saved = status === 200;
                this.notSaved = status !== 200;
                this.edit = status === 200;
            });
    }
}

export default UserProfile;

enum UserDataType {
    FIO,
    Email,
    Phone
}