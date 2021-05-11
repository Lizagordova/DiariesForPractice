import { PracticeReadModel } from "../Typings/readModels/PracticeReadModel";
import { PracticeViewModel } from "../Typings/viewModels/PracticeViewModel";
import {StudentTaskViewModel} from "../Typings/viewModels/StudentTaskViewModel";
import {StudentTaskReadModel} from "../Typings/readModels/StudentTaskReadModel";
import {StudentCharacteristicViewModel} from "../Typings/viewModels/StudentCharacteristicViewModel";

class PracticeStore {
    constructor() {
    }   
    
   async addOrUpdatePracticeDetails(practiceDetails: PracticeReadModel): Promise<number> {
       //todo: реализовать
        return 200;
    }
    
    async getPracticeDetails(studentId: number): Promise<PracticeViewModel> {
        //todo: реализовать
        return new PracticeViewModel();
    }
    
    async getStudentTask(studentId: number): Promise<StudentTaskViewModel> {
        const response = await fetch("/getstudenttask", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
               studentId: studentId
            })
        });
        let studentTask = new StudentTaskViewModel();
        if(response.status === 200) {
            studentTask = await response.json();
        } else {
            studentTask.studentId = studentId;
        }
        
        return studentTask;
    }
    
    async addOrUpdateStudentTask(studentTask: StudentTaskReadModel): Promise<number> {
        const response = await fetch("/addorupdatestudenttask", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                studentTask //todo: опять хз сработает или нет
            })
        });
        
        return response.status;
    }

    async getStudentCharacteristic(studentId: number): Promise<StudentCharacteristicViewModel> {
        const response = await fetch("/getstudencharacteristic", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                studentId: studentId
            })
        });
        let studentCharacteristic = new StudentCharacteristicViewModel();
        if(response.status === 200) {
            studentCharacteristic = await response.json();
        } else {
            studentCharacteristic.studentId = studentId;
        }

        return studentCharacteristic;
    }

    async addOrUpdateStudentCharacteristic(studentCharacteristic: StudentCharacteristicViewModel): Promise<number> {
        const response = await fetch("/addorupdatestudentcharacteristic", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                studentCharacteristic //todo: опять хз сработает или нет
            })
        });

        return response.status;
    }
}

export default PracticeStore;