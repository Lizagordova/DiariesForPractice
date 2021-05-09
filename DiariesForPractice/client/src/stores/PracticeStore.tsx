import { PracticeReadModel } from "../Typings/readModels/PracticeReadModel";
import { PracticeViewModel } from "../Typings/viewModels/PracticeViewModel";

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
}

export default PracticeStore;