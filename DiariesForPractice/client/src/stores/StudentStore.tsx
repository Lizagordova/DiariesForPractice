import { StudentViewModel } from "../Typings/viewModels/StudentViewModel";
import { makeObservable, observable } from "mobx";
import { StudentsQueryReadModel } from "../Typings/readModels/StudentsQueryReadModel";

class StudentStore {
    studentsByQuery: StudentViewModel[] = new Array<StudentViewModel>();
    students: StudentViewModel[] = new Array<StudentViewModel>();

    constructor() {
        makeObservable(this, {
            studentsByQuery: observable,
            students: observable,
        });
        this.setInitialData();
    }

    setInitialData() {
        this.searchStudentsByQuery(new StudentsQueryReadModel());
    }

    async searchStudentsByQuery(query: StudentsQueryReadModel) {

    }
}

export default StudentStore;