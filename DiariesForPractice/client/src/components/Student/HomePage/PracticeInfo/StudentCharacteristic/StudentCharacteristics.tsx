import React, {Component} from "react";
import {observer} from "mobx-react";
import {makeObservable, observable} from "mobx";
import {Button, Input, Label} from "reactstrap";
import {ProgressBar} from "react-bootstrap";
import PracticeStore from "../../../../../stores/PracticeStore";
import {StudentCharacteristicViewModel} from "../../../../../Typings/viewModels/StudentCharacteristicViewModel";
import {StudentCharacteristicType} from "../../../../../consts/StudentCharacteristicType";
import {translateStudentCharacteristicType} from "../../../../../functions/translater";
import {mapToStudentCharacteristicReadModel} from "../../../../../functions/mapper";
import {ToggleType} from "../../../../../consts/ToggleType";
import {renderProgress} from "../../../../../functions/progress";

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

    renderCharacteristicWithTextArea(characteristic: string | number, characteristicType: StudentCharacteristicType) {
        console.log("characteristic", characteristic, "characteristicType", characteristicType);
        if(characteristic === null || characteristic === undefined) {
            characteristic = "";
        }
        let type = translateStudentCharacteristicType(characteristicType);
        return (
            <>
                <div className="col-lg-3 col-md-3 col-sm-12">
                    <Label className="studentInfoDataLabel">{type}:</Label>
                </div>
                <div className="col-lg-9 col-md-9 col-sm-12">
                    <textarea
                        onInput={() => this.editToggle(ToggleType.on)}
                        className="studentInfoInput"
                        value={characteristic}
                        onChange={(event) => this.textAreaChange(event, characteristicType)}/>
                </div>
            </>
        );
    }

    renderCharacteristicWithInput(characteristic: string | number, characteristicType: StudentCharacteristicType) {
        console.log("characteristic", characteristic, "characteristicType", characteristicType);
        if(characteristic === null || characteristic === undefined) {
            characteristic = "";
        }
        let type = translateStudentCharacteristicType(characteristicType);
        return (
            <>
                <div className="col-lg-3 col-md-3 col-sm-12">
                    <Label className="studentInfoDataLabel">{type}:</Label>
                </div>
                <div className="col-lg-9 col-md-9 col-sm-12">
                    <Input
                        onInput={() => this.editToggle(ToggleType.on)}
                        className="studentInfoInput"
                        value={characteristic}
                        onChange={(event) => this.inputChange(event, characteristicType)}/>
                </div>
            </>
        );
    }
    
    renderHeader(edit: boolean) {
        return(
            <>
                <Label className="studentInfoTitleLabel">Характеристика студента</Label>
                {edit && <i className="fa fa-save fa-2x icon" onClick={() => this.save()}/>}
                {edit && <i className="fa fa-window-close fa-2x icon" onClick={() => this.editToggle(ToggleType.off)} />}

            </>
        );
    }

    render() {
        return (
            <>
                <div className="row justify-content-center">
                    {this.renderHeader(this.edit)}
                </div>
                <div className="row justify-content-center">
                    {renderProgress(true)}
                </div>
                <div className="row justify-content-center studentInfoBlock">
                    {this.renderCharacteristicWithTextArea(this.studentCharacteristics.descriptionByCafedraHead, StudentCharacteristicType.DescriptionByCafedraHead)}
                </div>
                <div className="row justify-content-center studentInfoBlock">
                    {this.renderCharacteristicWithTextArea(this.studentCharacteristics.descriptionByHead, StudentCharacteristicType.DescriptionByHead)}
                </div>
                <div className="row justify-content-center studentInfoBlock">
                    {this.renderCharacteristicWithInput(this.studentCharacteristics.missedDaysWithReason, StudentCharacteristicType.MissedDaysWithReason)}
                </div>
                <div className="row justify-content-center studentInfoBlock">
                    {this.renderCharacteristicWithInput(this.studentCharacteristics.missedDaysWithoutReason, StudentCharacteristicType.MissedDaysWithoutReason)}
                </div>
            </>
        );
    }

    textAreaChange(event: React.ChangeEvent<HTMLTextAreaElement>, type: StudentCharacteristicType) {
        let value = event.currentTarget.value;if (type === StudentCharacteristicType.DescriptionByCafedraHead) {
            this.studentCharacteristics.descriptionByCafedraHead = value;
        } else if (type === StudentCharacteristicType.DescriptionByHead) {
            this.studentCharacteristics.descriptionByHead = value;
        }
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
                if(status === 200) {
                    this.editToggle(ToggleType.off);
                    this.saved = status === 200;
                } else {
                    this.notSaved = true;
                }
            })
    }

    editToggle(type: ToggleType) {
        this.edit = type === ToggleType.on;
    }
}

export default StudentCharacteristics;