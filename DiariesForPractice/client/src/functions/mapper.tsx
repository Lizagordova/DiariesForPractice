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