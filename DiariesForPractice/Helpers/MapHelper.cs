using System.Linq;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.ReadModels;
using DiariesForPractice.Services.Mapper;
using DiariesForPractice.ViewModels;

namespace DiariesForPractice.Helpers
{
    public class MapHelper
    {
        private readonly MapperService _mapper;

        public MapHelper(MapperService mapper)
        {
            _mapper = mapper;
        }
        
        public PracticeDetails MapPracticeDetails(PracticeReadModel practiceReadModel)
        {
            var practiceDetails = _mapper.Map<PracticeReadModel, PracticeDetails>(practiceReadModel);
            practiceDetails.Student = new User() { Id = practiceReadModel.StudentId };
            practiceDetails.Organization = _mapper.Map<OrganizationReadModel, Organization>(practiceReadModel.Organization);
            practiceDetails.ResponsibleForStudent = _mapper.Map<StaffReadModel, Staff>(practiceReadModel.ResponsibleForStudent);
            practiceDetails.SignsTheContract = _mapper.Map<StaffReadModel, Staff>(practiceReadModel.ResponsibleForStudent);
            practiceDetails.CalendarPlan = _mapper.Map<CalendarPlanReadModel, CalendarPlan>(practiceReadModel.CalendarPlan);
            practiceDetails.StudentCharacteristic = _mapper.Map<StudentCharacteristicReadModel, StudentCharacteristic>(practiceReadModel.StudentCharacteristic);
            
            return practiceDetails;
        }

        public PracticeViewModel MapPracticeViewModel(PracticeDetails practiceDetails)
        {
            var practiceDetailsViewModel = _mapper.Map<PracticeDetails, PracticeViewModel>(practiceDetails);
            practiceDetailsViewModel.Organization = _mapper.Map<Organization, OrganizationViewModel>(practiceDetails.Organization);
            practiceDetailsViewModel.Student = _mapper.Map<User, UserViewModel>(practiceDetails.Student);
            practiceDetailsViewModel.CalendarPlan = MapCalendarPlanViewModel(practiceDetails.CalendarPlan);
            practiceDetailsViewModel.ResponsibleForStudent = _mapper.Map<Staff, StaffViewModel>(practiceDetails.ResponsibleForStudent);
            practiceDetailsViewModel.SignsTheContract = _mapper.Map<Staff, StaffViewModel>(practiceDetails.SignsTheContract);
            practiceDetailsViewModel.StudentTask = _mapper.Map<StudentTask, StudentTaskViewModel>(practiceDetails.StudentTask);

            return practiceDetailsViewModel;
        }

        public CalendarPlanViewModel MapCalendarPlanViewModel(CalendarPlan calendarPlan)
        {
            var calendarPlanViewModel = _mapper.Map<CalendarPlan, CalendarPlanViewModel>(calendarPlan);
            calendarPlanViewModel.CalendarWeekPlans = calendarPlan.CalendarPlanWeeks
                .Select(_mapper.Map<CalendarPlanWeek, CalendarWeekPlanViewModel>)
                .ToList();

            return calendarPlanViewModel;
        }
    }
}