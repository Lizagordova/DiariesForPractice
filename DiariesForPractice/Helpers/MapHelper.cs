using System.Collections.Generic;
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
            practiceDetailsViewModel.StudentCharacteristic = _mapper.Map<StudentCharacteristic, StudentCharacteristicViewModel>(practiceDetails.StudentCharacteristic);

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

        public CalendarPlan MapCalendarPlan(CalendarPlanReadModel calendarPlanReadModel)
        {
            var calendarPlan = _mapper.Map<CalendarPlanReadModel, CalendarPlan>(calendarPlanReadModel);
            calendarPlan.CalendarPlanWeeks = calendarPlanReadModel.CalendarWeekPlans
                .Select(_mapper.Map<CalendarWeekPlanReadModel, CalendarPlanWeek>)
                .ToList();

            return calendarPlan;
        }

        public CommentGroup MapCommentGroup(CommentGroupReadModel commentGroupReadModel)
        {
            var commentGroup = _mapper.Map<CommentGroupReadModel, CommentGroup>(commentGroupReadModel);
            commentGroup.Comments = new List<Comment>()
            {
                _mapper.Map<CommentReadModel, Comment>(commentGroupReadModel.Comment)
            };

            return commentGroup;
        }
        
        public CommentGroupViewModel MapCommentGroupViewModel(CommentGroup commentGroup)
        {
            var commentGroupViewModel = _mapper.Map<CommentGroup, CommentGroupViewModel>(commentGroup);
            commentGroupViewModel.Comments = commentGroup.Comments.Select(_mapper.Map<Comment, CommentViewModel>).ToList();

            return commentGroupViewModel;
        }

        public Institute MapInstitute(InstituteReadModel instituteReadModel)
        {
            var institute = _mapper.Map<InstituteReadModel, Institute>(instituteReadModel);
            institute.Cafedras = instituteReadModel.Cafedras.Select(MapCafedra).ToList();
            
            return institute;
        }
        
        public InstituteViewModel MapInstituteViewModel(Institute institute)
        {
            var instituteViewModel = _mapper.Map<Institute, InstituteViewModel>(institute);
            instituteViewModel.Cafedras = institute.Cafedras.Select(MapCafedraViewModel).ToList();
            
            return instituteViewModel;
        }
        
        public Cafedra MapCafedra(CafedraReadModel cafedraReadModel)
        {
            var cafedra = _mapper.Map<CafedraReadModel, Cafedra>(cafedraReadModel);
            cafedra.Directions = cafedraReadModel.Directions.Select(MapDirection).ToList();
            
            return cafedra;
        }
        
        public CafedraViewModel MapCafedraViewModel(Cafedra cafedra)
        {
            var cafedraViewModel = _mapper.Map<Cafedra, CafedraViewModel>(cafedra);
            cafedraViewModel.Directions = cafedra.Directions.Select(MapDirectionViewModel).ToList();
            
            return cafedraViewModel;
        }
        
        public Direction MapDirection(DirectionReadModel directionReadModel)
        {
            var direction = _mapper.Map<DirectionReadModel, Direction>(directionReadModel);
            direction.Groups = directionReadModel.Groups.Select( _mapper.Map<GroupReadModel, Group>).ToList();
            
            return direction;
        }
        
        public DirectionViewModel MapDirectionViewModel(Direction direction)
        {
            var directionViewModel = _mapper.Map<Direction, DirectionViewModel>(direction);
            directionViewModel.Groups = direction.Groups.Select(_mapper.Map<Group, GroupViewModel>).ToList();
            
            return directionViewModel;
        }
        
        public Degree MapDegree(DegreeReadModel degreeReadModel)
        {
            var degree = _mapper.Map<DegreeReadModel, Degree>(degreeReadModel);
            degree.Courses = degreeReadModel.Courses.Select(_mapper.Map<CourseReadModel, Course>).ToList();
            
            return degree;
        }
        
        public DegreeViewModel MapDegreeViewModel(Degree degree)
        {
            var degreeViewModel = _mapper.Map<Degree, DegreeViewModel>(degree);
            degreeViewModel.Courses = degree.Courses.Select(_mapper.Map<Course, CourseViewModel>).ToList();
            
            return degreeViewModel;
        }
    }
}