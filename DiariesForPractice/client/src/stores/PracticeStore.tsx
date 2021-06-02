import { PracticeReadModel } from "../Typings/readModels/PracticeReadModel";
import { PracticeViewModel } from "../Typings/viewModels/PracticeViewModel";
import {StudentTaskViewModel} from "../Typings/viewModels/StudentTaskViewModel";
import {StudentTaskReadModel} from "../Typings/readModels/StudentTaskReadModel";
import {StudentCharacteristicViewModel} from "../Typings/viewModels/StudentCharacteristicViewModel";
import {CalendarPlanReadModel} from "../Typings/readModels/CalendarPlanReadModel";
import {CalendarPlanViewModel} from "../Typings/viewModels/CalendarPlanViewModel";

class PracticeStore {
    constructor() {
    }   
    
   async addOrUpdatePracticeDetails(practiceDetails: PracticeReadModel): Promise<number> {
       const response = await fetch("/addorupdatestudenttask", {
           method: "POST",
           headers: {
               'Content-Type': 'application/json;charset=utf-8'
           },
           body: JSON.stringify({
               practiceDetails //todo: опять хз сработает или нет
           })
       });
       let id = 0;
       if(response.status === 200) {
           id = await response.json();
       }

       return id;
    }
    
    async getPracticeDetails(studentId: number): Promise<PracticeViewModel> {
        let practiceDetails = new PracticeViewModel();
        const response = await fetch(`/getpracticedetailsbystudentid?studentId=${studentId}`);
        if(response.status === 200) {
            practiceDetails = await response.json();
        }
        
        return practiceDetails;
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
    
    async addOrUpdateCalendarPlan(calendarPlan: CalendarPlanReadModel): Promise<number> {
        const response = await fetch("/addorupdatecalendarplan", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                calendarPlan //todo: опять хз сработает или нет
            })
        });
        
        return response.status;
    }
    
    async getCalendarPlan(studentId: number): Promise<CalendarPlanViewModel> {
        let calendarPlan = new CalendarPlanViewModel();
        const response = await fetch("/getcalendarplan", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                studentId: studentId
            })
        });
        if(response.status === 200) {
            calendarPlan = await response.json();  
        }
        
        return calendarPlan;
    }
}

export default PracticeStore;