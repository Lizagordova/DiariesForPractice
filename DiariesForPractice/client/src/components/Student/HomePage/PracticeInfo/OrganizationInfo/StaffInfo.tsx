import React, {Component} from "react";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";
import {Input, Label, Button, Alert} from "reactstrap";
import { StaffViewModel } from "../../../../../Typings/viewModels/StaffViewModel";
import { StaffRole } from "../../../../../Typings/enums/StaffRole";
import { translateStaffInfoType, translateStaffRole } from "../../../../../functions/translater";
import { StaffDataType } from "../../../../../consts/StaffDataType";
import { ProgressBar } from "react-bootstrap";
import OrganizationStore from "../../../../../stores/OrganizationStore";
import { mapToStaffReadModel } from "../../../../../functions/mapper";
import {StaffReadModel} from "../../../../../Typings/readModels/StaffReadModel";

class StaffInfoProps {
    staff: StaffViewModel;
    role: StaffRole;
    organizationId: number;
    organizationStore: OrganizationStore;
    practiceDetailsId: number;
}

@observer
class StaffInfo extends Component<StaffInfoProps> {
    staff: StaffViewModel = new StaffViewModel();
    edit: boolean;
    saved: boolean;
    notSaved: boolean;
    notOrganizationInfo: boolean;

    constructor(props: StaffInfoProps) {
        super(props);
        makeObservable(this, {
            staff: observable,
            edit: observable,
            saved: observable,
            notSaved: observable,
            notOrganizationInfo: observable
        });
        this.setStaff();
    }

    componentDidUpdate(prevProps: Readonly<StaffInfoProps>, prevState: Readonly<{}>, snapshot?: any) {
        if(prevProps.organizationId !== this.props.organizationId) {
            this.staff.organizationId = this.props.organizationId;
            this.notOrganizationInfo = false;
        }
    }

    setStaff() {
        let staff = this.props.staff;
        staff.organizationId = this.props.organizationId;
        this.staff = staff;
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
                {this.notOrganizationInfo && <Alert color="danger">Добавьте данные об организации сначала.</Alert>}
            </>
        );
    }
    
    renderData(data: string, type: StaffDataType, edit: boolean) {
        return (
            <>
                <div className="col-lg-3 col-md-3 col-sm-12">
                    <Label className="studentInfoDataLabel">{translateStaffInfoType(type)} :</Label>
                </div>
                <div className="col-lg-6 col-md-6 col-sm-12">
                    {!edit && <span>{data}</span>}
                    {edit && <Input
                        className="studentInfoInput"
                        value={data}
                        onChange={(event) => this.inputStaffData(event, type)}
                    />}
                </div>
                
            </>
        );
    }

    renderSectionProgress() {
        let progress = this.computeProgress(this.staff);
        return (
            <ProgressBar>{progress}</ProgressBar>
        );
    }
    
    renderHeader(staffRole: StaffRole) {
        return (
            <>
                <Label className="studentInfoTitleLabel">{translateStaffRole(staffRole)}</Label>
                {!this.edit && <i className="fa fa-edit fa-2x" onClick={() =>  this.editToggle()} />}
                {this.renderSectionProgress()}
            </>
        );
    }
    
    renderStaffInfo(edit: boolean) {
        return (
            <>
                <div className="row justify-content-center">
                    {this.renderHeader(this.props.role)}
                </div>
                <div className="row studentInfoBlock">
                    {this.renderData(this.staff.fullName, StaffDataType.FullName, edit)}
                </div>
                <div className="row studentInfoBlock">
                    {this.renderData(this.staff.job, StaffDataType.Job, edit)}
                </div>
                <div className="row studentInfoBlock">
                    {this.renderData(this.staff.email, StaffDataType.Email, edit)}
                </div>
                <div className="row studentInfoBlock">
                    {this.renderData(this.staff.phone, StaffDataType.Phone, edit)}
                </div>
            </>
        );
    }

    renderSaveButton() {
        return (
            <Button
                className="authButton"
                onClick={() => this.save()}
            >
                Сохранить
            </Button>
        );
    }
    
    render() {
        return (
            <>
                {this.renderWarnings()}
                {this.renderStaffInfo(this.edit)}
                {this.edit && <div className="row justify-content-center">
                    {this.renderSaveButton()}
                </div>}
            </>
        );
    }

    inputStaffData(event: React.ChangeEvent<HTMLInputElement>, dataType: StaffDataType) {
        let value = event.currentTarget.value;
        if(dataType === StaffDataType.FullName) {
            this.staff.fullName = value;
        } else if(dataType === StaffDataType.Job) {
            this.staff.job = value;
        } else if(dataType === StaffDataType.Phone) {
            this.staff.phone = value;
        } else if(dataType === StaffDataType.Email) {
            this.staff.email = value;
        }
    }

    editToggle() {
        this.edit = !this.edit;
    }

    computeProgress(staff: StaffViewModel) {
        let progress = "";
        if(staff.fullName !== "") {
            progress += 25;
        }
        if(staff.job !== "") {
            progress += 25;
        }
        if(staff.email !== "") {
            progress += 25;
        }
        if(staff.phone !== "") {
            progress += 25;
        }

        return progress;
    }

    save() {
        let staff = this.getStaffReadModel();
        if(staff.organizationId === 0) {
            this.notOrganizationInfo = true;
        } else {
            this.props.organizationStore.addOrUpdateStaff(staff)
                .then((staffId) => {
                    if(staffId !== 0) {
                        this.staff.id = staffId;
                        this.saved = true;
                    } else {
                        this.notSaved = true;
                    }
                });
        }
    }
    
    getStaffReadModel(): StaffReadModel {
        let staff = mapToStaffReadModel(this.staff, this.props.practiceDetailsId);
        staff.practiceDetailsId = this.props.practiceDetailsId;
        
        return staff;
    }
}

export default StaffInfo;