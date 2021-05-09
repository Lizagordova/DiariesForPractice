import React, { Component}  from "react";
import { observer } from "mobx-react";
import { OrganizationViewModel } from "../../../../Typings/viewModels/OrganizationViewModel";
import { makeObservable, observable } from "mobx";
import { Button, Input } from "reactstrap";
import { StaffViewModel } from "../../../../Typings/viewModels/StaffViewModel";
import { StaffRole } from "../../../../Typings/enums/StaffRole";
import StaffInfo from "./StaffInfo";

class OrganizationProps {
    organization: OrganizationViewModel;
    updateStaff: any;
    updateOrganization: any;
    edit: boolean;
}

@observer
class OrganizationInfo extends Component<OrganizationProps> {
    organization: OrganizationViewModel = new OrganizationViewModel();
    responsibleForStudent: StaffViewModel = new StaffViewModel();
    signsTheContract: StaffViewModel = new StaffViewModel();
    editInfo: boolean;
    
    constructor(props: OrganizationProps) {
        super(props);
        makeObservable(this, {
            organization: observable,
            responsibleForStudent: observable,
            signsTheContract: observable,
            editInfo: observable,
        });
        this.organization = this.props.organization;
    }

    renderOrganizationName() {
        return (
            <>
                {!this.editInfo && <span>{this.organization.name}</span>}
                {this.editInfo && <Input
                    value={this.organization.name}
                    onChange={(event) => this.inputData(event, OrganizationDataType.OrganizationName)}>
                    {this.organization.name}
                </Input>}
            </>
        );
    }

    renderOrganizationLegalAddress() {
        return (
            <>
                {!this.editInfo && <span>{this.organization.legalAddress}</span>}
                {this.editInfo && <Input
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
                <StaffInfo staff={staff} role={staffRole} edit={this.editInfo}  updateStaffInfo={this.updateStaffInfo}/>
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
                <div className="row justify-content-center">
                    {this.renderButton()}
                </div>
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

    updateStaffInfo(staff: StaffViewModel, staffRole: StaffRole) {
        if(staffRole === StaffRole.Responsible) {
            this.responsibleForStudent = staff;
        } else if(staffRole === StaffRole.SignsTheContract) {
            this.signsTheContract = staff;
        }
    }
}

export default OrganizationInfo;

enum OrganizationDataType {
    OrganizationName,
    OrganizationLegalAddress
}