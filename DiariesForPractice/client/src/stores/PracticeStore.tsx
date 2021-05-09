import { PracticeReadModel } from "../Typings/readModels/PracticeReadModel";

class PracticeStore {
    constructor() {
    }   
    
   async addOrUpdatePracticeDetails(practiceDetails: PracticeReadModel): Promise<number> {
        return 200;
    }
}

export default PracticeStore;