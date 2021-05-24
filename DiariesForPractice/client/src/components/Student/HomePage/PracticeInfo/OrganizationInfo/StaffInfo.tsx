import React, { Component } from "react";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";
import { Input, Label } from "reactstrap";
import { StaffViewModel } from "../../../../../Typings/viewModels/StaffViewModel";
import { StaffRole } from "../../../../../Typings/enums/StaffRole";
import {translateStaffRole} from "../../../../../functions/translater";

class StaffInfoProps {
    staff: StaffViewModel;
    role: StaffRole;
    updateStaff: any;
}

@observer
class StaffInfo extends Component<StaffInfoProps> {
    staff: StaffViewModel = new StaffViewModel();

    constructor(props: StaffInfoProps) {
        super(props);
        makeObservable(this, {
            staff: observable,
        });
    }

    renderFullName(fullName: string) {
        let { edit } = this.props;
        return (
            <>
                <Label>ФИО: </Label>
                {edit && <span>{fullName}</span>}
                {!edit && <Input
                    value={fullName}
                    onChange={(event) => this.inputStaffData(event, StaffDataType.FullName)}
                />}
            </>
        );
    }

    renderJob(job: string) {
        let { edit } = this.props;
        return(
            <>
                <Label>Должность: </Label>
                {edit && <span>{job}</span>}
                {!edit && <Input
                    value={job}
                    onChange={(event) => this.inputStaffData(event, StaffDataType.Job)}
                />}
            </>
        );
    }

    renderEmail(email: string) {
        let { edit } = this.props;
        return (
            <>
                <Label>Email</Label>
                {edit && <span>{email}</span>}
                {!edit && <Input
                    value={email}
                    onChange={(event) => this.inputStaffData(event, StaffDataType.Email)}
                />}
            </>
        );
    }

    renderPhone(phone: string) {
        let { edit } = this.props;
        return(
            <>
                <Label>Телефон: </Label>
                {edit && <span>{phone}</span>}
                {!edit && <Input
                    value={phone}
                    onChange={(event) => this.inputStaffData(event, StaffDataType.Phone)}
                />}
            </>
        );
    }

    renderHeader(staffRole: StaffRole) {
        return (
            <Label>
                {translateStaffRole(staffRole)}
            </Label>
        );
    }
    
    renderStaffInfo() {
        return (
            <>
                <div className="row justify-content-center">
                    {this.renderHeader(this.props.role)}
                </div>
                <div className="row justify-content-center">
                    {this.renderFullName(this.staff.fullName)}
                </div>
                <div className="row justify-content-center">
                    {this.renderJob(this.staff.job)}
                </div>
                <div className="row justify-content-center">
                    {this.renderEmail(this.staff.email)}
                </div>
                <div className="row justify-content-center">
                    {this.renderPhone(this.staff.phone)}
                </div>
            </>
        );
    }

    render() {
        return (
            <>
                {this.renderStaffInfo()}
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
        this.props.updateStaffInfo(this.staff, this.props.role);
    }
}

export default StaffInfo;

enum StaffDataType {
    FullName,
    Job,
    Email,
    Phone
}