import { PracticeReadModel } from "../Typings/readModels/PracticeReadModel";
import { PracticeViewModel } from "../Typings/viewModels/PracticeViewModel";
import { StudentTaskViewModel } from "../Typings/viewModels/StudentTaskViewModel";
import { StudentTaskReadModel } from "../Typings/readModels/StudentTaskReadModel";
import { StudentCharacteristicViewModel } from "../Typings/viewModels/StudentCharacteristicViewModel";
import { CalendarPlanReadModel } from "../Typings/readModels/CalendarPlanReadModel";
import { CalendarPlanViewModel } from "../Typings/viewModels/CalendarPlanViewModel";
import {StudentCharacteristicReadModel} from "../Typings/readModels/StudentCharacteristicReadModel";

class PracticeStore {
    constructor() {
    }   
    
   async addOrUpdatePracticeDetails(practiceDetails: PracticeReadModel): Promise<number> {
       const response = await fetch("/addorupdatepracticedetails", {
           method: "POST",
           headers: {
               'Content-Type': 'application/json;charset=utf-8'
           },
           body: JSON.stringify({
               id: practiceDetails.id, studentId: practiceDetails.studentId,
               organization: practiceDetails.organization, reportingForm: practiceDetails.reportingForm,
               contractNumber: practiceDetails.contractNumber, responsibleForStudent: practiceDetails.responsibleForStudent,
               signsTheContract: practiceDetails.signsTheContract, practiceType: practiceDetails.practiceType,
               startDate: practiceDetails.startDate, endDate: practiceDetails.endDate,
               calendarPlan: practiceDetails.calendarPlan, studentCharacteristic: practiceDetails.studentCharacteristic,
               practiceDetails: practiceDetails.studentTask, structuralDivision: practiceDetails.structuralDivision
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
                studentTask: studentTask.id, studentId: studentTask.studentId,
                task: studentTask.task, practiceDetailsId: studentTask.practiceDetailsId,
            })
        });
        
        return response.status;
    }

    async getStudentCharacteristic(studentId: number): Promise<StudentCharacteristicViewModel> {
        const response = await fetch("/getstudentcharacteristics", {
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

    async addOrUpdateStudentCharacteristic(studentCharacteristic: StudentCharacteristicReadModel): Promise<number> {
        console.log("studen", studentCharacteristic);
        const response = await fetch("/addorupdatestudentcharacteristics", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                id: studentCharacteristic.id, studentId: studentCharacteristic.studentId,
                descriptionByHead: studentCharacteristic.descriptionByHead, descriptionByCafedraHead: studentCharacteristic.descriptionByCafedraHead,
                missedDaysWithReason: studentCharacteristic.missedDaysWithReason, missedDaysWithoutReason: studentCharacteristic.missedDaysWithoutReason,
                practiceDetailsId: studentCharacteristic.practiceDetailsId
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
                id: calendarPlan.id, pr: calendarPlan.practiceDetailsId,
                calendarWeekPlans: calendarPlan.calendarWeekPlans
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