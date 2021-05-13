import {UserRole} from "../Typings/enums/UserRole";
import {ReportingForm} from "../Typings/enums/ReportingForm";
import {ActionType} from "../consts/ActionType";

export function translateUserRole(userRole: UserRole): string {
    let role = "";
    if(userRole === UserRole.User) {
        role = "Пользователь";
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