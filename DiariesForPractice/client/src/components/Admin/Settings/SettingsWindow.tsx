import React, { Component } from "react";
import { Input, Button, Alert } from "reactstrap";
import { GoogleDetailsReadModel } from "../../../Typings/readModels/GoogleDetailsReadModel";
import { makeObservable, observable } from "mobx";
import { observer } from "mobx-react";
import { RootStore } from "../../../stores/RootStore";

class ISettingsWindowProps {
    store: RootStore;
    groupId: number;
}

@observer
class SettingsWindow extends Component<ISettingsWindowProps> {
    googleDetails: GoogleDetailsReadModel = new GoogleDetailsReadModel();
    notSaved: boolean;
    saved: boolean;
    
    constructor(props: ISettingsWindowProps) {
        super(props);
        makeObservable(this, {
            googleDetails: observable,
            notSaved: observable,
            saved: observable,
        });
        this.setGoogleDetails(this.props.groupId);
    }

    componentDidUpdate(prevProps: Readonly<ISettingsWindowProps>, prevState: Readonly<{}>, snapshot?: any): void {
        if(prevProps.groupId !== this.props.groupId) {
            this.setGoogleDetails(this.props.groupId);
        }
    }

    setGoogleDetails(groupId: number) {
        this.props.store.googleDetailsStore.getGoogleDetailsByGroup(groupId)
            .then((googleDetails) => {
                this.googleDetails = googleDetails;
            });
    }

    renderSpreadSheetIdInput() {
        return (
            <div className="row justify-content-center">
                <Input
                    onChange={(e) => this.inputSetting(e, SettingType.SpreadSheetId)}
                    className="settingInput"
                    placeholder="Введите SpreadSheetId" />
            </div>
        );
    }

    renderSpreadSheetNameInput() {
        return (
            <div className="row justify-content-center">
                <Input
                    onChange={(e) => this.inputSetting(e, SettingType.SheetName)}
                    className="settingInput"
                    placeholder="Введите SheetName"/>
            </div>
        );
    }

    renderFirstCellInput() {
        return (
            <div className="row justify-content-center">
                <Input
                    onChange={(e) => this.inputSetting(e, SettingType.FirstCell)}
                    className="settingInput"
                    placeholder="Введите адрес первой ячейки"/>
            </div>
        );
    }

    renderLastCellInput() {
        return (
            <div className="row justify-content-center">
                <Input
                    className="settingInput"
                    onChange={(e) => this.inputSetting(e, SettingType.LastCell)}
                    placeholder="Введите адрес последней ячейки"/>
            </div>
        );
    }
    
    renderSaveButton() {
        return(
            <Button
                outline
                className="saveButton"
                onClick={() =>  this.save()}>
                Сохранить
            </Button>
        );
    }

    renderWarnings() {
        setTimeout(() => {
            this.notSaved = false;
            this.saved = false;
        }, 6000);
        return (
            <>
                {this.notSaved && <Alert color="danger">Что-то пошло не так, и данные не сохранились</Alert>}
                {this.saved && <Alert color="success">Данные успешно сохранились</Alert>}
            </>
        );
    }

    render() {
        return (
            <div className="settingsWindow">
                {this.renderWarnings()}
                <div className="row justify-content-center" >
                    <div className="col-lg-6 col-md-6 col-sm-12 text-center">
                        {this.renderSpreadSheetIdInput()}
                    </div>
                    <div className="col-lg-6 col-md-6 col-sm-12 text-center">
                        {this.renderSpreadSheetNameInput()}
                    </div>
                </div>
                <div className="row justify-content-center">
                    <div className="col-lg-6 col-md-6 col-sm-12 text-center">
                        {this.renderFirstCellInput()}
                    </div>
                    <div className="col-lg-6 col-md-6 col-sm-12 text-center">
                        {this.renderLastCellInput()}
                    </div>
                </div>
                <div className="row justify-content-center" style={{padding: "15px 15px 15px 15px"}}>
                    {this.renderSaveButton()}
                </div>
            </div>
        );
    }

    save() {
        this.props.store.googleDetailsStore.addOrUpdateGoogleDetails(this.googleDetails)
            .then((status) => {
                this.notSaved = status !== 200;
                this.saved = status === 200;
            });
    }

    inputSetting(event: React.ChangeEvent<HTMLInputElement>, setting: SettingType) {
        if(setting === SettingType.SpreadSheetId) {
            this.googleDetails.spreadSheetId = event.target.value;
        } else if(setting === SettingType.SheetName) {
            this.googleDetails.sheetName = event.target.value;
        } else if(setting === SettingType.FirstCell) {
            this.googleDetails.firstCell = event.target.value;
        } else if(setting === SettingType.LastCell) {
            this.googleDetails.lastCell = event.target.value;
        }
    }
}

export default SettingsWindow;

enum SettingType {
    SpreadSheetId,
    SheetName,
    FirstCell,
    LastCell
}