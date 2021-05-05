import {UserRole} from "../Typings/enums/UserRole";

export function translateUserRole(userRole: UserRole): string {
    let role = "";
    if(userRole === UserRole.User) {
        role = "Пользователь";
    } else if(userRole === UserRole.Admin) {
        role = "Администратор";
    }
//todo: дополнить
    return role;
}