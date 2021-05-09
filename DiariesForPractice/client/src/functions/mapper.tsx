import { InstituteReadModel } from "../Typings/readModels/InstituteReadModel";
import { InstituteViewModel } from "../Typings/viewModels/InstituteViewModel";
import { UserViewModel } from "../Typings/viewModels/UserViewModel";
import { UserReadModel } from "../Typings/readModels/UserReadModel";
import { PracticeReadModel } from "../Typings/readModels/PracticeReadModel";
import {PracticeViewModel} from "../Typings/viewModels/PracticeViewModel";

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