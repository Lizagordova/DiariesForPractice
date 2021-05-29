import { makeObservable, observable } from "mobx";
import { DiaryViewModel } from "../Typings/viewModels/DiaryViewModel";
import {DiaryReadModel} from "../Typings/readModels/DiaryReadModel";

class DiariesStore {
    diaries: DiaryViewModel[] = new Array<DiaryViewModel>();

    constructor() {
        makeObservable(this, {
            diaries: observable
        });
    }

    async generateDiary(studentId: number): Promise<number> {
        const response = await fetch("/generatediary", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                studentId: studentId
            })
        });
        if(response.status === 200) {
            this.getDiaries();
        }

        return response.status;
    }

    async sendDiary(studentId: number) {
        
    }

    async getDiaries() {
        const response = await fetch("/getdiaries");
        if(response.status === 200) {
            this.diaries = await response.json();
        }
    }
    
    async getDiary(studentId: number): Promise<DiaryViewModel> {
        const response = await fetch(`getdiary?studentId=${studentId}`);
        let diary = new DiaryViewModel();
        if(response.status === 200) {
            diary = await response.json();
        }
        
        return diary;
    }

    async addOrUpdateDiary(diary: DiaryReadModel): Promise<number> {
        const response = await fetch("/addorupdatediary", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(diary)
        });
        
        return response.status;
    }
}

export default DiariesStore;