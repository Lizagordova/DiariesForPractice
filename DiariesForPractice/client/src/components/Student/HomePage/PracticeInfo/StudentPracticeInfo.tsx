import React, {Component} from "react";
import {observer} from "mobx-react";
import {RootStore} from "../../../../stores/RootStore";
import OrganizationInfo from "./OrganizationInfo/OrganizationInfo";
import StaffInfo from "./OrganizationInfo/StaffInfo";
import {StaffRole} from "../../../../Typings/enums/StaffRole";
import {PracticeViewModel} from "../../../../Typings/viewModels/PracticeViewModel";
import {makeObservable, observable} from "mobx";
import {OrganizationViewModel} from "../../../../Typings/viewModels/OrganizationViewModel";
import {StaffViewModel} from "../../../../Typings/viewModels/StaffViewModel";

class StudentPracticeInfoProps {
    store: RootStore;
}

@observer
class StudentPracticeInfo extends Component<StudentPracticeInfoProps> {
    practiceDetails: PracticeViewModel = new PracticeViewModel();
    
    constructor(props: StudentPracticeInfoProps) {
        super(props);
        makeObservable(this, {
           practiceDetails: observable 
        });
    }
    
    renderOrganizationInfo() {
        return (
            <OrganizationInfo organization={this.practiceDetails.organization} store={this.props.store} updateOrganization={this.updateOrganization}/>
        );
    }
    
    renderStaffInfo(staff: StaffViewModel, role: StaffRole) {
        return (
            <>
                <StaffInfo staff={staff} role={role} updateStaff={this.updateStaff}/>
            </>
        );
    }
    
    render() {
        return (
            <>
                {this.renderOrganizationInfo()}
                {this.renderStaffInfo(this.practiceDetails.responsibleForStudent, StaffRole.Responsible)}
                {this.renderStaffInfo(this.practiceDetails.signsTheContract, StaffRole.SignsTheContract)}
            </>
        );
    }

    updateOrganization(organization: OrganizationViewModel) {
        this.practiceDetails.organization = organization;
    }

    updateStaff(staff: StaffViewModel, role: StaffRole) {
        if(role === StaffRole.Responsible) {
            this.practiceDetails.responsibleForStudent = staff;
        } else if(role === StaffRole.SignsTheContract) {
            this.practiceDetails.signsTheContract = staff;
        }
    }
}

export default StudentPracticeInfo;