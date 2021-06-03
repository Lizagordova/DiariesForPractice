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
    }

    componentDidUpdate(prevProps: Readonly<ISettingsWindowProps>, prevState: Readonly<{}>, snapshot?: any): void {
        if(prevProps.groupId !== this.props.groupId) {
            
        }
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
                
                <div className="row justify-content-center" style={{padding: "15px 15px 15px 15px"}}>
                    {this.renderSaveButton()}
                </div>
            </div>
        );
    }

    save() {
        
    }

}

export default SettingsWindow;

enum SettingType {
    SpreadSheetId,
    SheetName,
    FirstCell,
    LastCell
}