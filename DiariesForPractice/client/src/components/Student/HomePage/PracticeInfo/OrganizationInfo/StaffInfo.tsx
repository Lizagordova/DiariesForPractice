import React, {Component} from "react";
import {observer} from "mobx-react";
import {makeObservable, observable} from "mobx";
import {Alert, Input, Label } from "reactstrap";
import {StaffViewModel} from "../../../../../Typings/viewModels/StaffViewModel";
import {StaffRole} from "../../../../../Typings/enums/StaffRole";
import {translateStaffInfoType, translateStaffRole} from "../../../../../functions/translater";
import {StaffDataType} from "../../../../../consts/StaffDataType";
import OrganizationStore from "../../../../../stores/OrganizationStore";
import {mapToStaffReadModel} from "../../../../../functions/mapper";
import {StaffReadModel} from "../../../../../Typings/readModels/StaffReadModel";
import {ToggleType} from "../../../../../consts/ToggleType";
import {renderProgress} from "../../../../../functions/progress";

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
    updateProgressBar: boolean;

    constructor(props: StaffInfoProps) {
        super(props);
        makeObservable(this, {
            staff: observable,
            edit: observable,
            saved: observable,
            notSaved: observable,
            notOrganizationInfo: observable,
            updateProgressBar: observable,
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
    
    renderData(data: string, type: StaffDataType) {
        return (
            <>
                <div className="col-lg-3 col-md-3 col-sm-12">
                    <Label className="studentInfoDataLabel">{translateStaffInfoType(type)} :</Label>
                </div>
                <div className="col-lg-9 col-md-9 col-sm-12">
                    <Input
                        onInput={() => this.editToggle(ToggleType.on)}
                        className="studentInfoInput"
                        value={data}
                        onChange={(event) => this.inputStaffData(event, type)}>
                        {data}
                    </Input>
                </div>
            </>
        );
    }

    componentDidMount() {
        {this.updateProgress()}
    }

    updateProgress() {
        let progress = this.computeProgress(this.staff);
        console.log("this.refs", this.refs)
        let progressBar = this.refs["progress1"];
        console.log("progressBar", progressBar)
        //@ts-ignore
        progressBar.style.width = progress;
        this.updateProgressBar = !this.updateProgressBar;
    }
    
    renderHeader(staffRole: StaffRole, edit: boolean) {
        return (
            <>
                <Label className="studentInfoTitleLabel">{translateStaffRole(staffRole)}</Label>
                {edit && <i className="fa fa-save fa-2x icon" onClick={() => this.save()}/>}
                {edit && <i className="fa fa-window-close fa-2x icon" onClick={() => this.editToggle(ToggleType.off)} />}
            </>
        );
    }
    
    renderStaffInfo() {
        return (
            <>
                <div className="row justify-content-center">
                    {this.renderHeader(this.props.role, this.edit)}
                </div>
                <div className="row justify-content-center">
                    {renderProgress(this.updateProgressBar)}
                </div>
                <div className="row studentInfoBlock">
                    {this.renderData(this.staff.fullName, StaffDataType.FullName)}
                </div>
                <div className="row studentInfoBlock">
                    {this.renderData(this.staff.job, StaffDataType.Job)}
                </div>
                <div className="row studentInfoBlock">
                    {this.renderData(this.staff.email, StaffDataType.Email)}
                </div>
                <div className="row studentInfoBlock">
                    {this.renderData(this.staff.phone, StaffDataType.Phone)}
                </div>
                
            </>
        );
    }
    
    render() {
        return (
            <>
                {this.renderWarnings()}
                {this.renderStaffInfo()}
            </>
        );
    }

    inputStaffData(event: React.ChangeEvent<HTMLInputElement>, dataType: StaffDataType) {
        let value = event.currentTarget.value;
        if(value === null) {
            value = "";
        }
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

    editToggle(type: ToggleType) {
        this.edit = type === ToggleType.on;
    }

    computeProgress(staff: StaffViewModel): number {
        let progress = 0;
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