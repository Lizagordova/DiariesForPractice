import { UserRole } from "../Typings/enums/UserRole";
import { ReportingForm } from "../Typings/enums/ReportingForm";

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