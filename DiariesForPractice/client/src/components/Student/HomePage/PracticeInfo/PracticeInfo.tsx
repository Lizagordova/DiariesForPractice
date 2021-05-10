import React, { Component}  from "react";
import { observer } from "mobx-react";
import { OrganizationViewModel } from "../../../../Typings/viewModels/OrganizationViewModel";
import { StaffViewModel } from "../../../../Typings/viewModels/StaffViewModel";
import { RootStore } from "../../../../stores/RootStore";
import { makeObservable, observable } from "mobx";
import { PracticeViewModel } from "../../../../Typings/viewModels/PracticeViewModel";
import { Input, Alert, Button } from "reactstrap";
import { StaffRole } from "../../../../Typings/enums/StaffRole";
import { mapToPracticeDetailsReadModel } from "../../../../functions/mapper";
import OrganizationInfo from "./OrganizationInfo";

class PracticeInfoProps {
    store: RootStore;
}

@observer
class PracticeInfo extends Component<PracticeInfoProps> {
    practiceDetails: PracticeViewModel = new PracticeViewModel();
    responsibleForStudent: StaffViewModel = new StaffViewModel();
    signsTheContract: StaffViewModel = new StaffViewModel();
    saved: boolean;
    notSaved: boolean;
    editInfo: boolean;
    
    constructor(props: PracticeInfoProps) {
        super(props);
        makeObservable(this, {
            practiceDetails: observable,
            saved: observable,
            notSaved: observable,
            editInfo: observable,
            responsibleForStudent: observable,
            signsTheContract: observable,
        });
        this.setPracticeDetails();
    }

    setPracticeDetails() {
        let currentStudentId = this.props.store.userStore.currentUser.id;
        this.props.store.practiceStore.getPracticeDetails(currentStudentId)
            .then((practiceDetails) => {
                this.practiceDetails = practiceDetails;
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

    renderOrganizationInfo() {
        return (
            <OrganizationInfo
                organization={this.practiceDetails.organization} 
                updateStaff={this.updateStaffInfo} 
                updateOrganization={this.updateOrganization}
                edit={this.editInfo} 
                responsibleForStudent={this.responsibleForStudent}
                signsTheContract={this.signsTheContract} />
        );
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
    
    render() {
        return(
            <>
                {this.renderOrganizationInfo()}
                <div className="row justify-content-center">
                    {this.renderButton()}
                </div>
            </>
        );
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

    updateOrganization(organization: OrganizationViewModel) {
        this.practiceDetails.organization = organization;
    }

    updateStaffInfo(staff: StaffViewModel, staffRole: StaffRole) {
        if(staffRole === StaffRole.Responsible) {
            this.practiceDetails.responsibleForStudent = staff;
        } else if(staffRole === StaffRole.SignsTheContract) {
            this.practiceDetails.signsTheContract = staff;
        }
    }

    editInfoToggle() {
        this.editInfo = !this.editInfo;
    }
}

export default PracticeInfo;