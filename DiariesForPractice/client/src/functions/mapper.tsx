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
import {DiaryViewModel} from "../Typings/viewModels/DiaryViewModel";
import {DiaryReadModel} from "../Typings/readModels/DiaryReadModel";
import {CafedraViewModel} from "../Typings/viewModels/CafedraViewModel";
import {CafedraReadModel} from "../Typings/readModels/CafedraReadModel";

export function mapToInstituteReadModel(instituteViewModel: InstituteViewModel): InstituteReadModel {
    let institute = new InstituteReadModel();
    institute.id = instituteViewModel.id;
    institute.name = instituteViewModel.name;
    institute.cafedras = instituteViewModel.cafedras.map((cafedra) => {
        return mapToCafedraReadModel(cafedra);
    });
    
    return institute;
}

export function mapUserReadModel(userViewModel: UserViewModel): UserReadModel {
    let user = new UserReadModel();
    user.id = userViewModel.id;
    user.email = userViewModel.email;
    user.firstName = userViewModel.firstName;
    user.lastName = userViewModel.lastName;
    user.secondName = userViewModel.secondName;
    return new UserReadModel();
}

export function mapToPracticeDetailsReadModel(practiceViewModel: PracticeViewModel): PracticeReadModel {
    let practice = new PracticeReadModel();
    practice.id = practiceViewModel.id;
    practice.organization = mapToOrganizationReadModel(practiceViewModel.organization);
    practice.contractNumber = practiceViewModel.contractNumber;
    practice.reportingForm = practiceViewModel.reportingForm;
    practice.signsTheContract = mapToStaffReadModel(practiceViewModel.signsTheContract);
    practice.responsibleForStudent = mapToStaffReadModel(practiceViewModel.responsibleForStudent);
    practice.endDate = practiceViewModel.endDate;
    practice.startDate = practiceViewModel.startDate;
    practice.structuralDivision = practiceViewModel.structuralDivision;
   // practice.studentId = practiceViewModel.studentId;
    practice.calendarPlan = mapToCalendarPlanReadModel(practiceViewModel.calendarPlan);
    practice.studentCharacteristic = mapToStudentCharacteristicReadModel(practiceViewModel.studentCharacteristic);
    practice.studentTask = mapToStudentTaskReadModel(practiceViewModel.studentTask);
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

export function mapToDiaryReadModel(diary: DiaryViewModel): DiaryReadModel {
    //todo: реализовать
    return new DiaryReadModel();
}

export function mapToCafedraReadModel(cafedraViewModel: CafedraViewModel): CafedraReadModel {
    return new CafedraReadModel();
}