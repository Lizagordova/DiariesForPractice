import React, { Component } from "react";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";
import { Label, Input, Button } from "reactstrap";
import { ProgressBar } from "react-bootstrap";
import PracticeStore from "../../../../../stores/PracticeStore";
import { StudentCharacteristicViewModel } from "../../../../../Typings/viewModels/StudentCharacteristicViewModel";
import { StudentCharacteristicType } from "../../../../../consts/StudentCharacteristicType";
import { translateStudentCharacteristicType } from "../../../../../functions/translater";
import {mapToStudentCharacteristicReadModel} from "../../../../../functions/mapper";

class StudentCharacteristicsProps {
    practiceStore: PracticeStore;
    studentCharacteristic: StudentCharacteristicViewModel;
    practiceDetailsId: number;
}

@observer
class StudentCharacteristics extends Component<StudentCharacteristicsProps> {
    studentCharacteristics: StudentCharacteristicViewModel = new StudentCharacteristicViewModel();
    edit: boolean;
    saved: boolean;
    notSaved: boolean;

    constructor(props: StudentCharacteristicsProps) {
        super(props);
        makeObservable(this, {
            studentCharacteristics: observable,
            edit: observable,
            saved: observable,
            notSaved: observable
        });
        this.setStudentCharacteristics();
    }

    setStudentCharacteristics() {
        this.studentCharacteristics = this.props.studentCharacteristic;
    }

    renderSectionProgress() {
        let progress = this.computeProgress(this.studentCharacteristics);
        return (
            <ProgressBar>
                {progress}
            </ProgressBar>
        );
    }

    renderCharacteristic(edit: boolean, characteristic: string | number, characteristicType: StudentCharacteristicType) {
        let type = translateStudentCharacteristicType(characteristicType);
        return (
            <>
                <Label>{type}</Label>
                {!edit && <span>{characteristic}</span>}
                {edit && <Input
                    placeholder={type}
                    value={characteristic}
                    onChange={(event) => this.inputChange(event, characteristicType)}
                />}
            </>
        );
    }

    renderHeader() {
        return(
            <>
                <Label>Характеристика студента</Label>
                {!this.edit && <i className="fa fa-edit fa-2x" onClick={() =>  this.editToggle()} />}
                {this.renderSectionProgress()}
            </>
        );
    }

    renderSaveButton() {
        return (
            <Button
                className="authButton"
                onClick={() => this.save()}>
                Сохранить
            </Button>
        );
    }
    
    render() {
        return (
            <>
                <div className="row justify-content-center">
                    {this.renderHeader()}
                </div>
                <div className="row justify-content-center">
                    {this.renderCharacteristic(this.edit, this.studentCharacteristics.descriptionByCafedraHead, StudentCharacteristicType.DescriptionByCafedraHead)}
                </div>
                <div className="row justify-content-center">
                    {this.renderCharacteristic(this.edit, this.studentCharacteristics.descriptionByHead, StudentCharacteristicType.DescriptionByHead)}
                </div>
                <div className="row justify-content-center">
                    {this.renderCharacteristic(this.edit, this.studentCharacteristics.missedDaysWithReason, StudentCharacteristicType.MissedDaysWithReason)}
                </div>
                <div className="row justify-content-center">
                    {this.renderCharacteristic(this.edit, this.studentCharacteristics.missedDaysWithoutReason, StudentCharacteristicType.MissedDaysWithoutReason)}
                </div>
                {this.edit && <div className="row justify-content-center">
                    {this.renderSaveButton()}
                </div>}
            </>
        );
    }

    inputChange(event: React.ChangeEvent<HTMLInputElement>, type: StudentCharacteristicType) {
        let value = event.currentTarget.value;
        if(type === StudentCharacteristicType.MissedDaysWithoutReason) {
            this.studentCharacteristics.missedDaysWithReason = Number(value);
        } else if (type === StudentCharacteristicType.MissedDaysWithReason) {
            this.studentCharacteristics.missedDaysWithReason = Number(value);
        } else if (type === StudentCharacteristicType.DescriptionByCafedraHead) {
            this.studentCharacteristics.descriptionByCafedraHead = value;
        } else if (type === StudentCharacteristicType.DescriptionByHead) {
            this.studentCharacteristics.descriptionByHead = value;
        }
    }

    computeProgress(studentCharacteristic: StudentCharacteristicViewModel): number {
        let progress = 0;
        if(studentCharacteristic.descriptionByHead !== "") {
            progress += 50;
        }
        if(studentCharacteristic.descriptionByCafedraHead !== "") {
            progress += 50;
        }

        return progress;
    }

    save() {
        let studentCharacteristic = mapToStudentCharacteristicReadModel(this.studentCharacteristics, this.props.practiceDetailsId);
        this.props.practiceStore.addOrUpdateStudentCharacteristic(studentCharacteristic)
            .then((status) => {
                this.saved = status === 200;
                this.notSaved = status !== 200;
                this.edit = status !== 200;
            })
    }

    editToggle() {
        this.edit = !this.edit;
    }
}

export default StudentCharacteristics;