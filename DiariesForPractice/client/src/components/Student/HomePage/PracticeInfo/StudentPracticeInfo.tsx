import React, {Component} from "react";
import {observer} from "mobx-react";
import {RootStore} from "../../../../stores/RootStore";
import OrganizationInfo from "./OrganizationInfo/OrganizationInfo";
import StaffInfo from "./OrganizationInfo/StaffInfo";
import {StaffRole} from "../../../../Typings/enums/StaffRole";
import {PracticeViewModel} from "../../../../Typings/viewModels/PracticeViewModel";
import {makeObservable, observable, toJS} from "mobx";
import { OrganizationViewModel} from "../../../../Typings/viewModels/OrganizationViewModel";
import {StaffViewModel} from "../../../../Typings/viewModels/StaffViewModel";
import PracticeDetailsInfo from "./PracticeDetailsInfo";
import StudentTask from "./StudentTask";
import StudentCharacteristics from "./StudentCharacteristic/StudentCharacteristics";
import CalendarPlan from "./CalendarPlan/CalendarPlan";
import { renderSpinner } from "../../../../functions/renderSpinner";

class StudentPracticeInfoProps {
    store: RootStore;
}

@observer
class StudentPracticeInfo extends Component<StudentPracticeInfoProps> {
    practiceDetails: PracticeViewModel = new PracticeViewModel();
    update: boolean;
    loaded: boolean = false;
    
    constructor(props: StudentPracticeInfoProps) {
        super(props);
        makeObservable(this, {
           practiceDetails: observable,
           update: observable,
            loaded: observable
        });
        this.setPracticeDetails();
    }

    setPracticeDetails() {
        let studentId = this.props.store.userStore.currentUser.id;
        this.props.store.practiceStore
            .getPracticeDetails(studentId)
            .then((practiceDetails) => {
                this.practiceDetails = practiceDetails;
                this.loaded = true;
            });
    }
    
    renderOrganizationInfo(update: boolean) {
        return (
            <OrganizationInfo 
                organization={this.practiceDetails.organization}
                store={this.props.store} 
                practiceDetailsId={this.practiceDetails.id} 
                updateOrganization={this.updateOrganization}
            />
        );
    }

    renderStaffInfo(staff: StaffViewModel, role: StaffRole) {
        return (
            <>
                <StaffInfo
                    staff={staff}
                    role={role}
                    organizationId={this.practiceDetails.organization.id}
                    organizationStore={this.props.store.organizationStore}
                    practiceDetailsId={this.practiceDetails.id}
                />
            </>
        );
    }

    renderPracticeDetails(update: boolean) {
        return (
            <PracticeDetailsInfo
                practiceStore={this.props.store.practiceStore}
                practiceDetails={this.practiceDetails}
            />
        );
    }

    renderStudentTask(update: boolean) {
        return (
            <StudentTask 
                studentTask={this.practiceDetails.studentTask}
                practiceStore={this.props.store.practiceStore}
                practiceDetailsId={this.practiceDetails.id}
            />
        );
    }

    renderStudentCharacteristic(update: boolean) {
        return (
            <StudentCharacteristics
                practiceStore={this.props.store.practiceStore}
                practiceDetailsId={this.practiceDetails.id}
                studentCharacteristic={this.practiceDetails.studentCharacteristic}
            />
        );
    }

    renderCalendarPlan(update: boolean) {
        return (
            <CalendarPlan
                practiceStore={this.props.store.practiceStore}
                practiceDetailsId={this.practiceDetails.id}
                calendarPlan={this.practiceDetails.calendarPlan}
            />
        );
    }
    
    renderStudentInfo() {
        return (
            <>
                {this.renderOrganizationInfo(this.update)}
                {this.renderStaffInfo(this.practiceDetails.responsibleForStudent, StaffRole.Responsible)}
                {this.renderStaffInfo(this.practiceDetails.signsTheContract, StaffRole.SignsTheContract)}
                {this.renderPracticeDetails(this.update)}
                {this.renderStudentTask(this.update)}
                {this.renderStudentCharacteristic(this.update)}
                {this.renderCalendarPlan(this.update)}
            </>
        );
    }
    
    render() {
        return (
            <>
                {this.loaded && this.renderStudentInfo()}
                {!this.loaded && renderSpinner()}
            </>
        );
    }

    updateOrganization = (organization: OrganizationViewModel) => {
        this.practiceDetails.organization = organization;
    }
}

export default StudentPracticeInfo;