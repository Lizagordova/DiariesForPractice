import React, { Component}  from "react";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";
import { Input, Label, Button, Alert } from "reactstrap";
import { OrganizationViewModel } from "../../../../../Typings/viewModels/OrganizationViewModel";
import { ProgressBar } from "react-bootstrap";
import { RootStore } from "../../../../../stores/RootStore";
import {mapToOrganizationReadModel} from "../../../../../functions/mapper";

class OrganizationProps {
    organization: OrganizationViewModel;
    store: RootStore;
    practiceDetailsId: number;
    updateOrganization: any;
}

@observer
class OrganizationInfo extends Component<OrganizationProps> {
    organization: OrganizationViewModel = new OrganizationViewModel();
    edit: boolean;
    notSaved: boolean;
    saved: boolean;

    constructor(props: OrganizationProps) {
        super(props);
        makeObservable(this, {
            organization: observable,
            edit: observable,
            notSaved: observable,
            saved: observable,
        });
        this.setOrganization();
    }

    setOrganization() {
        this.organization = this.props.organization;
    }
    
    renderWarnings() {
        setTimeout(() => {
            this.saved = false;
            this.notSaved = false;
        });
        return (
            <>
                {this.saved && <Alert>Данные успешно сохранены!</Alert>}
                {this.notSaved && <Alert>Что-то пошло не так и данные не сохранились.</Alert>}
            </>
        );
    }
    
    renderOrganizationName(organizationName: string, edit: boolean) {
        return (
            <>
                <Label>Название организации</Label>
                {!edit && <span>{organizationName}</span>}
                {edit && <Input
                    value={organizationName}
                    onChange={(event) => this.inputData(event, OrganizationDataType.OrganizationName)}>
                    {organizationName}
                </Input>}
            </>
        );
    }

    renderOrganizationLegalAddress(legalAddress: string, edit: boolean) {
        return (
            <>
                <Label>Юридический адрес</Label>
                {!edit && <span>{legalAddress}</span>}
                {edit && <Input
                    value={legalAddress}
                    onChange={(event) => this.inputData(event, OrganizationDataType.OrganizationName)}>
                    {legalAddress}
                </Input>}
            </>
        );
    }

    renderSectionProgress() {
        let progress = this.computeProgress(this.organization);
        return (
            <ProgressBar>{progress}</ProgressBar>
        );
    }

    renderHeader(edit: boolean) {
        return (
            <>
                <Label>Организация</Label>
                {!edit && <i className="fas fa-edit fa-2x" onClick={() =>  this.editToggle()} />}
                {this.renderSectionProgress()}
            </>
        );
    }

    renderSaveButton() {
        return (
            <Button
                outline color="success"
                onClick={() => this.save()}>
                Сохранить
            </Button>
        );
    }
    
    renderOrganizationInfo(organization: OrganizationViewModel, edit: boolean) {
        return (
            <>
                {this.renderWarnings()}
                <div className="row justify-content-center">
                    {this.renderHeader(edit)}
                </div>
                <div className="row justify-content-center">
                    {this.renderOrganizationName(organization.name, this.edit)}
                </div>
                <div className="row justify-content-center">
                    {this.renderOrganizationLegalAddress(organization.legalAddress, edit)}
                </div>
                {this.edit && <div className="row justify-content-center">
                    {this.renderSaveButton()}
                </div>}
            </>
        );
    }

    render() {
        return(
            <></>
        );
    }

    inputData(event: React.ChangeEvent<HTMLInputElement>,organizationType: OrganizationDataType) {
        let value = event.currentTarget.value;
        if(organizationType === OrganizationDataType.OrganizationName) {
            this.organization.name = value;
        } else if(organizationType === OrganizationDataType.OrganizationLegalAddress) {
            this.organization.legalAddress = value;
        }
    }

    computeProgress(organization: OrganizationViewModel): number {
        let progress = 0;
        if(organization.name !== "") {
            progress += 50;
        }
        if(organization.legalAddress !== "") {
            progress += 50;
        }

        return progress;
    }

    editToggle() {
        this.edit = !this.edit;
    }

    save() {
        let organization = mapToOrganizationReadModel(this.organization, this.props.practiceDetailsId);
        this.props.store.organizationStore.addOrUpdateOrganization(organization)
            .then((organizationId) => {
                if(organizationId === 0) {
                    this.notSaved = true;
                } else {
                    this.saved = true;
                    let organization = new OrganizationViewModel();
                    organization.id = organizationId;
                    this.organization = organization;
                    this.props.updateOrganization(organization);
                }
            });
    }
}

export default OrganizationInfo;

enum OrganizationDataType {
    OrganizationName,
    OrganizationLegalAddress
}