import { InstituteReadModel } from "../Typings/readModels/InstituteReadModel";
import { InstituteViewModel } from "../Typings/viewModels/InstituteViewModel";
import { UserViewModel } from "../Typings/viewModels/UserViewModel";
import { UserReadModel } from "../Typings/readModels/UserReadModel";
import { PracticeReadModel } from "../Typings/readModels/PracticeReadModel";
import {PracticeViewModel} from "../Typings/viewModels/PracticeViewModel";
import {StudentTaskReadModel} from "../Typings/readModels/StudentTaskReadModel";
import {StudentTaskViewModel} from "../Typings/viewModels/StudentTaskViewModel";
import {StudentCharacteristicViewModel} from "../Typings/viewModels/StudentCharacteristicViewModel";
import {StudentCharacteristicReadModel} from "../Typings/readModels/StudentCharacteristicReadModel";
import {GroupViewModel} from "../Typings/viewModels/GroupViewModel";
import {GroupReadModel} from "../Typings/readModels/GroupReadModel";
import {OrganizationViewModel} from "../Typings/viewModels/OrganizationViewModel";
import {OrganizationReadModel} from "../Typings/readModels/OrganizationReadModel";
import {StaffViewModel} from "../Typings/viewModels/StaffViewModel";
import {StaffReadModel} from "../Typings/readModels/StaffReadModel";
import {CalendarPlanViewModel} from "../Typings/viewModels/CalendarPlanViewModel";
import {CalendarPlanReadModel} from "../Typings/readModels/CalendarPlanReadModel";
import {CalendarWeekPlanViewModel} from "../Typings/viewModels/CalendarWeekPlanViewModel";
import {CalendarWeekPlanReadModel} from "../Typings/readModels/CalendarWeekPlanReadModel";

export function mapToInstituteReadModel(instituteViewModel: InstituteViewModel): InstituteReadModel {
    //todo: реализовать
    return new InstituteReadModel();
}

export function mapUserReadModel(userViewModel: UserViewModel): UserReadModel {
    //todo: реализовать
    return new UserReadModel();
}

export function mapToPracticeDetailsReadModel(practiceViewModel: PracticeViewModel): PracticeReadModel {
    //todo: реализовать
    return new PracticeReadModel(); 
}

export function mapToStudentTaskReadModel(studentTask: StudentTaskViewModel): StudentTaskReadModel {
    //todo: реализовать
    return new StudentTaskReadModel();
}

export function mapToStudentCharacteristicReadModel(studentCharacteristic: StudentCharacteristicViewModel): StudentCharacteristicReadModel {
    //todo: реализовать
    return new StudentCharacteristicReadModel();
}

export function mapToGroupReadModel(group: GroupViewModel): GroupReadModel {
    //todo: реализовать
    return new GroupReadModel();
}

export function mapToOrganizationReadModel(organization: OrganizationViewModel): OrganizationReadModel {
    //todo: реализовать
    return new OrganizationReadModel();
}

export function mapToStaffReadModel(staff: StaffViewModel): StaffReadModel {
    //todo: реализовать
    return new StaffReadModel();
}

export function mapToCalendarPlanReadModel(calendarPlan: CalendarPlanViewModel): CalendarPlanReadModel {
    //todo: реализовать
    return new CalendarPlanReadModel;
}

export function mapToCalendarWeekPlanReadModel(calendarWeekPlan: CalendarWeekPlanViewModel): CalendarWeekPlanReadModel {
    //todo: реализовать
    return new CalendarWeekPlanViewModel();
}