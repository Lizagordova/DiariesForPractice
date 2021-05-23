import {UserRole} from "../Typings/enums/UserRole";
import {ReportingForm} from "../Typings/enums/ReportingForm";
import {ActionType} from "../consts/ActionType";
import {StaffRole} from "../Typings/enums/StaffRole";
import {PracticeType} from "../Typings/enums/PracticeType";

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