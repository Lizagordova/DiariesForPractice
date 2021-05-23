import React, { Component } from "react";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";
import { Label } from "reactstrap";
import { ProgressBar } from "react-bootstrap";
import PracticeStore from "../../../../../stores/PracticeStore";
import { StudentCharacteristicViewModel } from "../../../../../Typings/viewModels/StudentCharacteristicViewModel";

class StudentCharacteristicsProps {
    practiceStore: PracticeStore;
    studentId: number;
}

@observer
class StudentCharacteristics extends Component<StudentCharacteristicsProps> {
    studentCharacteristics: StudentCharacteristicViewModel = new StudentCharacteristicViewModel();
    edit: boolean;

    constructor(props: StudentCharacteristicsProps) {
        super(props);
        makeObservable(this, {
            studentCharacteristics: observable,
            edit: observable
        });
        this.setStudentCharacteristics();
    }

    setStudentCharacteristics() {
        this.props.practiceStore
            .getStudentCharacteristic(this.props.studentId)
            .then((studentCharacteristic) => {
                this.studentCharacteristics = studentCharacteristic;
            });
    }

    renderSectionProgress() {
        let progress = this.computeProgress(this.studentCharacteristics);
        return (
            <ProgressBar>
                {progress}
            </ProgressBar>
        );
    }

    renderDescriptionByHead() {
        return (
            <>
            </>
        );
    }

    renderMissedDaysWithoutReason() {
        return (
            <>
                <Label>

                </Label>
            </>
        );
    }

    renderMissedDaysWithReason() {
        return (
            <></>
        );
    }

    renderDescriptionByCafedraHead() {
        return (
            <></>
        );
    }

    renderHeader() {

    }
    render() {
        return (
            <></>
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
}

export default StudentCharacteristics;

enum StudentCharacteristicType {
    DescriptionByHead,
    DescriptionByCafedraHead,
    MissedDaysWithReason,
    MissedDaysWithoutReason
}