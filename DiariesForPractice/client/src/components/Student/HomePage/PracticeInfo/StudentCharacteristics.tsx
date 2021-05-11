import React, { Component } from "react";
import { observer } from "mobx-react";
import { StudentCharacteristicViewModel } from "../../../../Typings/viewModels/StudentCharacteristicViewModel";
import { makeObservable, observable } from "mobx";
import PracticeStore from "../../../../stores/PracticeStore";
import { Label, Button, Input, Alert } from "reactstrap";
import { mapToStudentCharacteristicReadModel } from "../../../../functions/mapper";

class StudentCharacteristicProps {
    practiceStore: PracticeStore;
    studentId: number;
}

@observer
class StudentCharacteristics extends Component<StudentCharacteristicProps> {
    studentCharacteristics: StudentCharacteristicViewModel = new StudentCharacteristicViewModel();
    edit: boolean;
    saved: boolean;
    notSaved: boolean;
    
    constructor(props: StudentCharacteristicProps) {
        super(props);
        makeObservable(this, {
            studentCharacteristics: observable,
            edit: observable,
            saved: observable,
            notSaved: observable,
        });
    }
    
    setStudentCharacteristics() {
        let { studentId } = this.props;
        this.props.practiceStore.getStudentCharacteristic(studentId)
            .then((studentCharacteristics) => {
                this.studentCharacteristics = studentCharacteristics;
            });
    }
    
    renderWarnings() {
        setTimeout(() => {
            this.notSaved = false;
            this.saved = false;
        }, 6000);
        return (
            <>
                {this.notSaved && <Alert color="dander">Что-то пошло не так, и данные не обновились!</Alert>}
                {this.saved && <Alert color="success">Данные успешно сохранились!</Alert>}
            </>
        )
    }
    
    renderDescriptionByHead(descriptionByHead: string, edit: boolean) {
        return (
            <div className="row justify-content-center">
                <Label>
                    Характеристика от руководителя:
                </Label>
                {!edit && <span>{descriptionByHead}</span>}
                {edit && <Input
                    value={descriptionByHead}
                    onChange={(event) => this.changeCharacteristicDataType(event, CharacteristicDataType.DescriptionByHead)}
                />}
            </div>
        );
    }
    
    renderMissedDaysWithoutReason(missedDaysWithoutReason: number, edit: boolean) {
        return (
            <div className="row justify-content-center">
                <Label>
                    Количество пропущенных дней без уважительной причины:
                </Label>
                {!edit && <span>{missedDaysWithoutReason}</span>}
                {edit && <Input
                    value={missedDaysWithoutReason}
                    onChange={(event) => this.changeCharacteristicDataType(event, CharacteristicDataType.MissedDaysWithoutReason)}
                />}
            </div>
        );
    }

    renderDescriptionByCafedraHead(descriptionByCafedraHead: string, edit: boolean) {
        return (
            <div className="row justify-content-center">
                <Label>
                    Характеристика от руководителя практики от кафедры:
                </Label>
                {!edit && <span>{descriptionByCafedraHead}</span>}
                {edit && <Input
                    value={descriptionByCafedraHead}
                    onChange={(event) => this.changeCharacteristicDataType(event, CharacteristicDataType.DescriptionByCafedraHead)}
                />}
            </div>
        );
    }

    renderMissedDaysWithReason(missedDaysWithReason: number, edit: boolean) {
        return (
            <div className="row justify-content-center">
                <Label>
                    Количество пропущенных дней по уважительной причине:
                </Label>
                {!edit && <span>{missedDaysWithReason}</span>}
                {edit && <Input>
                    
                </Input>}
            </div>
        );
    }
    
    renderStudentCharacteristics(studentCharacteristics: StudentCharacteristicViewModel) {
        return (
            <>
                {this.renderDescriptionByHead(studentCharacteristics.descriptionByHead, this.edit)}
                {this.renderDescriptionByCafedraHead(studentCharacteristics.descriptionByCafedraHead, this.edit)}
                {this.renderMissedDaysWithReason(studentCharacteristics.missedDaysWithReason, this.edit)}
                {this.renderMissedDaysWithoutReason(studentCharacteristics.missedDaysWithoutReason, this.edit)}
            </>
        );
    }

    renderButton(edit: boolean) {
        if(edit) {
            return (
                <Button
                    outline color="primary"
                    onClick={() => this.save()}>
                    Сохранить
                </Button>
            );
        } else {
            return (
                <Button
                    outline color="primary"
                    onClick={() => this.editToggle()}>
                    Редактировать
                </Button>
            );
        }
    }
    
    render() {
        return (
            <>
                {this.renderWarnings()}
                {this.renderStudentCharacteristics(this.studentCharacteristics)}
                {this.renderButton(this.edit)}
            </>
        );
    }
    
    changeCharacteristicDataType(event: React.ChangeEvent<HTMLInputElement>, type: CharacteristicDataType) {
        let value = event.currentTarget.value;
        if(type === CharacteristicDataType.DescriptionByHead) {
            this.studentCharacteristics.descriptionByHead = value;
        } else if(type === CharacteristicDataType.DescriptionByCafedraHead) {
            this.studentCharacteristics.descriptionByCafedraHead = value;
        } else if(type === CharacteristicDataType.MissedDaysWithoutReason) {
            this.studentCharacteristics.missedDaysWithoutReason = Number(value);
        } else if(type === CharacteristicDataType.MissedDaysWithReason) {
            this.studentCharacteristics.missedDaysWithReason = Number(value);
        }
    }
    
    editToggle() {
        this.edit = !this.edit;
    }

    save() {
        let studentCharacteristic = mapToStudentCharacteristicReadModel(this.studentCharacteristics);
        this.props.practiceStore.addOrUpdateStudentCharacteristic(studentCharacteristic)
            .then((status) => {
                this.saved = status === 200;
                this.notSaved = status !== 200;
            })
    }
}

export default StudentCharacteristics;

enum CharacteristicDataType {
    DescriptionByHead,
    DescriptionByCafedraHead,
    MissedDaysWithReason,
    MissedDaysWithoutReason
}
