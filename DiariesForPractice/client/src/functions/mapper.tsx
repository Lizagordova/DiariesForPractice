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
import {DirectionViewModel} from "../Typings/viewModels/DirectionViewModel";
import {DirectionReadModel} from "../Typings/readModels/DirectionReadModel";
import CalendarPlan from "../components/Student/HomePage/PracticeInfo/CalendarPlan/CalendarPlan";
import {CommentViewModel} from "../Typings/viewModels/CommentViewModel";

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
    user.role = userViewModel.role;
    user.phone = userViewModel.phone;
    
    return user;
}

export function mapToPracticeDetailsReadModel(practiceViewModel: PracticeViewModel): PracticeReadModel {
    let practice = new PracticeReadModel();
    practice.id = practiceViewModel.id;
    practice.organization = mapToOrganizationReadModel(practiceViewModel.organization, practiceViewModel.id);
    practice.contractNumber = practiceViewModel.contractNumber;
    practice.reportingForm = practiceViewModel.reportingForm;
    practice.signsTheContract = mapToStaffReadModel(practiceViewModel.signsTheContract, practiceViewModel.id);
    practice.responsibleForStudent = mapToStaffReadModel(practiceViewModel.responsibleForStudent, practiceViewModel.id);
    practice.endDate = practiceViewModel.endDate;
    practice.startDate = practiceViewModel.startDate;
    practice.structuralDivision = practiceViewModel.structuralDivision;
    practice.studentId = practiceViewModel.student.id;
    practice.calendarPlan = mapToCalendarPlanReadModel(practiceViewModel.calendarPlan, practiceViewModel.id);
    practice.studentCharacteristic = mapToStudentCharacteristicReadModel(practiceViewModel.studentCharacteristic, practiceViewModel.id);
    practice.studentTask = mapToStudentTaskReadModel(practiceViewModel.studentTask, practiceViewModel.id);
    
    return practice; 
}

export function mapToStudentTaskReadModel(studentTaskViewModel: StudentTaskViewModel, practiceDetailsId: number): StudentTaskReadModel {
    let studentTask = new StudentTaskReadModel();
    studentTask.studentId = studentTaskViewModel.studentId;
    studentTask.id = studentTaskViewModel.id;
    studentTask.task = studentTaskViewModel.task;
    studentTask.practiceDetailsId = practiceDetailsId;
    
    return studentTask;
}

export function mapToStudentCharacteristicReadModel(studentCharacteristicViewModel: StudentCharacteristicViewModel, practiceDetailsId: number): StudentCharacteristicReadModel {
    let studentCharactestic = new StudentCharacteristicReadModel();
    studentCharactestic.id = studentCharacteristicViewModel.id;
    studentCharactestic.studentId = studentCharacteristicViewModel.studentId;
    studentCharactestic.practiceDetailsId = practiceDetailsId;
    studentCharactestic.descriptionByCafedraHead = studentCharacteristicViewModel.descriptionByCafedraHead;
    studentCharactestic.descriptionByHead = studentCharacteristicViewModel.descriptionByHead;
    studentCharactestic.missedDaysWithReason = studentCharacteristicViewModel.missedDaysWithReason;
    studentCharactestic.missedDaysWithoutReason = studentCharacteristicViewModel.missedDaysWithoutReason;
    
    return studentCharactestic;
}

export function mapToGroupReadModel(groupViewModel: GroupViewModel): GroupReadModel {
    let group = new GroupReadModel();
    group.id = groupViewModel.id;
    group.name = groupViewModel.name;
    group.courseId = groupViewModel.courseId;
    group.directionId = groupViewModel.directionId;
    //todo: добавить мб
    
    return group;
}

export function mapToOrganizationReadModel(organizationViewModel: OrganizationViewModel, practiceDetailsId: number): OrganizationReadModel {
    let organization = new OrganizationReadModel();
    organization.id = organizationViewModel.id;
    organization.name = organizationViewModel.name;
    organization.legalAddress = organizationViewModel.legalAddress;
    organization.practiceDetailsId = practiceDetailsId;
    
    return organization;
}

export function mapToStaffReadModel(staffViewModel: StaffViewModel, practiceDetailsId: number): StaffReadModel {
    let staff = new StaffReadModel();
    staff.id = staffViewModel.id;
    staff.email = staffViewModel.email;
    staff.practiceDetailsId = practiceDetailsId;
    staff.job = staffViewModel.job;
    staff.phone = staffViewModel.phone;
    staff.organizationId = staffViewModel.organizationId;
    staff.fullName = staffViewModel.fullName;
    
    return staff;
}

export function mapToCalendarPlanReadModel(calendarPlanViewModel: CalendarPlanViewModel, practiceDetailsId: number): CalendarPlanReadModel {
    let calendarPlan = new CalendarPlanReadModel();
    calendarPlan.id = calendarPlanViewModel.id;
    calendarPlan.practiceDetailsId = practiceDetailsId;
    calendarPlan.calendarWeekPlans = calendarPlanViewModel.calendarWeekPlans.map((calendarPlanWeek) => {
        return mapToCalendarWeekPlanReadModel(calendarPlanWeek);
    });
    
    return calendarPlan;
}

export function mapToCalendarWeekPlanReadModel(calendarWeekPlanViewModel: CalendarWeekPlanViewModel): CalendarWeekPlanReadModel {
    let calendarWeekPlan = new CalendarWeekPlanReadModel();
    calendarWeekPlan.id = calendarWeekPlanViewModel.id;
    calendarWeekPlan.endDate = calendarWeekPlanViewModel.endDate;
    calendarWeekPlan.order = calendarWeekPlanViewModel.order;
    calendarWeekPlan.startDate = calendarWeekPlanViewModel.startDate;
    calendarWeekPlan.structuralDivision = calendarWeekPlanViewModel.structuralDivision;
    calendarWeekPlan.nameOfTheWork = calendarWeekPlanViewModel.nameOfTheWork;
    
    return calendarWeekPlan;
}

export function mapToDiaryReadModel(diaryViewModel: DiaryViewModel): DiaryReadModel {
    let diary = new DiaryReadModel();
    diary.id = diaryViewModel.id;
    diary.perceivedDate = diaryViewModel.perceivedDate;
    diary.comment = diaryViewModel.comment;
    diary.path = diaryViewModel.path;
    diary.send = diaryViewModel.send;
    diary.completion = diaryViewModel.completion;
    diary.generated = diaryViewModel.generated;
    diary.generatedDate = diaryViewModel.generatedDate;
    diary.studentId = diaryViewModel.studentId;

    return diary;
}

export function mapToCafedraReadModel(cafedraViewModel: CafedraViewModel): CafedraReadModel {
    let cafedra = new CafedraReadModel();
    cafedra.id = cafedraViewModel.id;
    cafedra.name = cafedraViewModel.name;
    cafedra.instituteId = cafedraViewModel.instituteId;
    cafedra.directions = cafedraViewModel.directions.map((direction) => {
        return mapToDirectionReadModel(direction);
    });
    
    return cafedra;
}

export function mapToDirectionReadModel(directionViewModel: DirectionViewModel): DirectionReadModel {
    let direction = new DirectionReadModel();
    direction.id = directionViewModel.id;
    direction.name = directionViewModel.name;
    direction.cafedraId = directionViewModel.cafedraId;
    direction.groups = directionViewModel.groups.map((group) => {
        return mapToGroupReadModel(group);
    });
    
    return direction;
}