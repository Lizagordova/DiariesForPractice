import React, { Component}  from "react";
import { observer } from "mobx-react";
import { OrganizationViewModel } from "../../../../Typings/viewModels/OrganizationViewModel";
import { StaffViewModel } from "../../../../Typings/viewModels/StaffViewModel";
import { RootStore } from "../../../../stores/RootStore";
import { makeObservable, observable } from "mobx";
import { PracticeViewModel } from "../../../../Typings/viewModels/PracticeViewModel";
import { Input, Alert } from "reactstrap";
import StaffInfo from "./StaffInfo";
import { StaffRole } from "../../../../Typings/enums/StaffRole";
import {mapToPracticeDetailsReadModel} from "../../../../functions/mapper";

class PracticeInfoProps {
    store: RootStore;
    edit: boolean;
}

@observer
class PracticeInfo extends Component<PracticeInfoProps> {
    organization: OrganizationViewModel = new OrganizationViewModel();
    responsibleForStudent: StaffViewModel = new StaffViewModel();
    signsTheContract: StaffViewModel = new StaffViewModel();
    practiceDetails: PracticeViewModel = new PracticeViewModel();
    saved: boolean;
    notSaved: boolean;
    
    constructor(props: PracticeInfoProps) {
        super(props);
        makeObservable(this, {
            organization: observable,
            responsibleForStudent: observable,
            signsTheContract: observable,
            practiceDetails: observable,
            saved: observable,
            notSaved: observable,
        });
    }

    renderWarnings() {
        setTimeout(() => {
            this.notSaved = false;
            this.saved = false;
        }, 6000);
        return (
            <>
                {this.saved && <Alert color="success">Данные успешно обновлены!</Alert>}
                {this.notSaved && <Alert color="danger">Что-то пошло не так и данные не обновились!</Alert>}
            </>
        );
    }
    
    renderOrganizationName() {
        let { edit } = this.props;
        return (
            <>
                {!edit && <span>{this.organization.name}</span>}
                {edit && <Input
                    value={this.organization.name}
                    onChange={(event) => this.inputData(event, OrganizationDataType.OrganizationName)}>
                    {this.organization.name}
                </Input>}
            </>
        );
    }

    renderOrganizationLegalAddress() {
        let { edit } = this.props;
        return (
            <>
                {!edit && <span>{this.organization.legalAddress}</span>}
                {edit && <Input
                    value={this.organization.legalAddress}
                    onChange={(event) => this.inputData(event, OrganizationDataType.OrganizationName)}>
                    {this.organization.name}
                </Input>}
            </>
        );
    }

    renderStaff(staff: StaffViewModel, staffRole: StaffRole) {
        return (
            <>
                <StaffInfo staff={staff} role={staffRole} edit={this.props.edit}  updateStaffInfo={this.updateStaffInfo}/>
            </>
        );
    }
    
    renderOrganizationInfo() {
        return (
            <>
                <div className="row justify-content-center">
                    {this.renderOrganizationName()}
                </div>
                <div className="row justify-content-center">
                    {this.renderOrganizationLegalAddress()}
                </div>
                <div className="row justify-content-center">
                    {this.renderStaff(this.responsibleForStudent, StaffRole.Responsible)}
                </div>
                <div className="row justify-content-center">
                    {this.renderStaff(this.signsTheContract, StaffRole.SignsTheContract)}
                </div>
            </>
        );
    }
    
    render() {
        return(
            <>
                {this.renderOrganizationInfo()}  
            </>
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
    
    updateStaffInfo(staff: StaffViewModel, staffRole: StaffRole) {
        if(staffRole === StaffRole.Responsible) {
            this.responsibleForStudent = staff;
        } else if(staffRole === StaffRole.SignsTheContract) {
            this.signsTheContract = staff;
        }
    }
    
    save() {
        let practiceDetails = mapToPracticeDetailsReadModel(this.practiceDetails);
        this.props.store.practiceStore
            .addOrUpdatePracticeDetails(practiceDetails)
            .then((status) => {
                this.saved = status === 200;
                this.notSaved = status !== 200;
            });
    }
        
}

export default PracticeInfo;

enum OrganizationDataType {
    OrganizationName,
    OrganizationLegalAddress
}