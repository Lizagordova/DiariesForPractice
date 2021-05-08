import React, { Component } from "react";
import { observer } from "mobx-react";
import { Button } from "reactstrap";
import { makeObservable, observable } from "mobx";
import { RootStore } from "../../../../stores/RootStore";
import PersonalInfo from "./PersonalInfo";
import OrganizationInfo from "./OrganizationInfo";

class PracticeInfoProps {
    store: RootStore;
}

@observer
class PracticeInfo extends Component<PracticeInfoProps> {
    editInfo: boolean;
    
    constructor(props: PracticeInfoProps) {
        super(props);
        makeObservable(this, {
            editInfo: observable
        });
    }
    
    renderButton() {
        if(this.editInfo) {
            return (
                <Button
                    color="secondary"
                    onClick={() => this.save()}>
                    Сохранить
                </Button>
            );
        } else {
            return (
                <Button
                    color="secondary"
                    onClick={() => this.editInfoToggle()}>
                    Редактировать
                </Button>
            );
        }
        
    }
    
    renderPracticeInfo() {
        return(
            <>
                <div className="row justify-content-center">
                    <PersonalInfo />
                </div>
                <div className="row justify-content-center">
                    <OrganizationInfo />
                </div>
                <div className="row justify-content-center">
                    
                </div>
                <div className="row justify-content-center">
                    {this.renderButton()}
                </div>
            </>
        );
    }
    
    render() {
        return (
            <>
                {this.renderPracticeInfo()}
            </>
        );
    }

    editInfoToggle() {
        this.editInfo = !this.editInfo;
    }
    
    save() {
        let { store } = this.props;
    }
}

export default PracticeInfo;