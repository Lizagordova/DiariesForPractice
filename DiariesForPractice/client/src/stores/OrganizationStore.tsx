import { OrganizationReadModel } from "../Typings/readModels/OrganizationReadModel";
import {OrganizationViewModel} from "../Typings/viewModels/OrganizationViewModel";
import {StaffReadModel} from "../Typings/readModels/StaffReadModel";

class OrganizationStore {
    constructor() {
    }
    
    async addOrUpdateOrganization(organization: OrganizationReadModel): Promise<number> {
        let organizationId = 0;
        const response = await fetch("/addorupdateorganization", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                id: organization.id, name: organization.name,
                legalAddress: organization.legalAddress, practiceDetailsId: organization.practiceDetailsId
            })
        });
        if(response.status === 200) {
            organizationId = await response.json();
        }
        
        return organizationId;        
    }
    
    async getOrganization(organizationId: number): Promise<OrganizationViewModel> {
        let organization = new OrganizationViewModel();
        const response = await fetch(`/getorganization?organizationId=${organizationId}`);//todo: опять хз может такое получиться или нет
        if(response.status === 200) {
            organization = await response.json();
        }
        
        return organization;
    }
    
    async addOrUpdateStaff(staff: StaffReadModel): Promise<number> {
        let staffId = 0;
        const response = await fetch("/addorupdatestaff", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                id: staff.id, organizationId: staff.organizationId,
                job: staff.job, phone: staff.phone, email: staff.email,
                fullName: staff.fullName, practiceDetailsId: staff.practiceDetailsId,
                role: staff.role
            })
        });
        if(response.status === 200) {
            
            staffId = await response.json();
        }

        return staffId;
    }
}

export default OrganizationStore;