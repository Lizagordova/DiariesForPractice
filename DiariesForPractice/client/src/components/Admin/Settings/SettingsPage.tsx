import React, { Component } from "react";
import { RootStore } from "../../../stores/RootStore";
import {Alert, Label} from "reactstrap";
import Filters from "../../Common/Home/Filters/Filters";
import SettingsWindow from "./SettingsWindow";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";
import {StudentsQueryReadModel} from "../../../Typings/readModels/StudentsQueryReadModel";

class ISettingsPageProps {
    store: RootStore;
}

@observer
class SettingsPage extends Component<ISettingsPageProps> {
    groupId: number = -1;
    
    constructor(props: ISettingsPageProps) {
        super(props);
        makeObservable(this, {
            groupId: observable
        });
    }

    renderTitle() {
        return (
            <div className="row justify-content-center" style={{marginTop: "5%", fontSize: "2.5em"}}>
                <Label>
                   Настройки
                </Label>
            </div>
        );
    }

    renderFilters() {
        return (
            <Filters store={this.props.store} updateFilters={this.updateFilters} />
        );
    }

    renderSettingsWindow() {
        if(this.groupId !== -1) {
            return (
                <SettingsWindow store={this.props.store} groupId={this.groupId} />
            );
        } else {
            return (
                <Alert color="primary" style={{marginTop: "1%"}}>Выберите группу, для которой нужно настроить данные google</Alert>
            );
        }
    }

    render() {
        return(
            <div className="container-fluid">
                {this.renderTitle()}
                {this.renderFilters()}
                {this.renderSettingsWindow()}
            </div>
        );
    }

    updateFilters(query: StudentsQueryReadModel) {
        this.groupId = query.groupId;
    }
}

export default SettingsPage;