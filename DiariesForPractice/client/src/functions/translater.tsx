﻿import {UserRole} from "../Typings/enums/UserRole";
import {ReportingForm} from "../Typings/enums/ReportingForm";
import {ActionType} from "../consts/ActionType";
import {StaffRole} from "../Typings/enums/StaffRole";
import {PracticeType} from "../Typings/enums/PracticeType";
import {StudentCharacteristicType} from "../consts/StudentCharacteristicType";
import {StaffDataType} from "../consts/StaffDataType";

export function translateUserRole(userRole: UserRole): string {
    let role = "";
    if(userRole === UserRole.User) {
        role = "Не выбрано";//todo: костыль
    } else if(userRole === UserRole.Admin) {
        role = "Администратор";
    } else if(userRole === UserRole.Teacher) {
        role = "Преподаватель";
    } else if(userRole === UserRole.Student) {
        role = "Студент";
    }
//todo: дополнить
    return role;
}

export function translateReportingForm(reportingForm: ReportingForm): string {
    let form = "";
    if(reportingForm === ReportingForm.Dogovor) {
        form = "Договор";
    } else if(reportingForm === ReportingForm.Spravka) {
        form = "Справка";
    }

    return form;
}

export function translateAction(actionType: ActionType): string {
    let action = "";
    if(actionType === ActionType.Add) {
        action = "Добавить";
    } else if(actionType === ActionType.Edit) {
        action = "Редактировать";
    } else if(actionType === ActionType.Remove) {
        action = "Удалить";
    }
    
    return action;
}

export function translateStaffRole(staffRole: StaffRole): string {
    let role = "";
    if(staffRole === StaffRole.Responsible) {
        role = "Ответственный";
    } else if(staffRole === StaffRole.SignsTheContract) {
        role = "Подписывает";
    }
    
    return role;
}

export function translatePracticeType(practiceType: PracticeType): string {
    let type = "";
    if(practiceType === PracticeType.Production) {
        return "Производственная";
    }
    return practiceType;
}

export function translateStudentCharacteristicType(characteristicType: StudentCharacteristicType): string {
    let type = "";
    if(characteristicType === StudentCharacteristicType.DescriptionByCafedraHead) {
        type = "Отзыв от руководителя кафедры";
    } else if(characteristicType === StudentCharacteristicType.DescriptionByHead) {
        type = "Отзыв от руководителя практики";
    } else if(characteristicType === StudentCharacteristicType.MissedDaysWithoutReason) {
        type = "Количество пропущенных дней без уважительной причины";
    } else if(characteristicType === StudentCharacteristicType.MissedDaysWithReason) {
        type = "Количество пропущенных дней по уважительной причине";
    }

    return type;
}

export function translateStaffInfoType(staffInfoType: StaffDataType): string {
    let type = "";
    if(staffInfoType === StaffDataType.FullName) {
        type = "Фио";
    } else if(staffInfoType === StaffDataType.Email) {
        type = "Email";
    } else if(staffInfoType === StaffDataType.Phone) {
        type = "Телефон";
    } else if(staffInfoType === StaffDataType.Job) {
        type = "Должность";
    }

    return type;
}