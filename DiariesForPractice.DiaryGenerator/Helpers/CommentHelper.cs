using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Models.Data;

namespace DiariesForPractice.DiaryGenerator.Helpers
{
    public static class CommentHelper
    {
        public static string GenerateComment(PracticeData data)
        {
            var comment = "";
            comment = AddPracticeDetailsComment(comment, data.PracticeDetails);
            comment = AddStudentCharacteristicComment(comment, data.StudentCharacteristic);
            comment = AddStudentTaskComment(comment, data.StudentTask);
            
            return comment;
        }

        private static string AddPracticeDetailsComment(string comment, PracticeDetails practiceDetails)
        {
            comment = AddOrganizationComment(comment, practiceDetails.Organization);
            comment = AddCalendarPlanComment(comment, practiceDetails.CalendarPlan);
            comment = AddStaffComment(comment, practiceDetails.ResponsibleForStudent);
            comment = AddStaffComment(comment, practiceDetails.SignsTheContract);
            if (string.IsNullOrEmpty(practiceDetails.ContractNumber))
            {
                comment += "Номер контракта: не указан; \n";
            }
            if (string.IsNullOrEmpty(practiceDetails.StructuralDivision))
            {
                comment += "Структурное подразделение: не выбрано; \n";
            }

            if (practiceDetails.PracticeType == PracticeType.None)
            {
                comment += "Тип практики: не выбран; \n";
            }
            if (practiceDetails.ReportingForm == ReportingForm.None)
            {
                comment += "Тип договора: не выбран; \n";
            }

            return comment;
        }
        
        private static string AddOrganizationComment(string comment, Organization organization)
        {
            if (string.IsNullOrEmpty(organization.Name))
            {
                comment += "Имя организации: не заполнено \n";
            }
            if (string.IsNullOrEmpty(organization.LegalAddress))
            {
                comment += "Юридический адрес организации: не заполнено \n";
            }

            return comment;
        }
        
        private static string AddCalendarPlanComment(string comment, CalendarPlan calendarPlan)
        {
            if (calendarPlan.CalendarPlanWeeks.Count == 0)
            {
                comment += "Календарный план: не заполнен \n";
            }

            return comment;
        }
        private  static string AddStudentCharacteristicComment(string comment, StudentCharacteristic studentCharacteristic)
        {
            if (string.IsNullOrEmpty(studentCharacteristic.DescriptionByHead))
            {
                comment += "Характеристика от руководителя: не заполнено \n";
            }
            if (string.IsNullOrEmpty(studentCharacteristic.DescriptionByCafedraHead))
            {
                comment += "Характеристика от руководителя кафедры: не заполнено \n";
            }
            if (studentCharacteristic.MissedDaysWithoutReason == 0)
            {
                comment += "Количество пропущенных дней без причины: не заполнено \n";
            }
            if (studentCharacteristic.MissedDaysWithReason == 0)
            {
                comment += "Количество пропущенных дней с уважительной причиной: не заполнено \n";
            }

            return comment;
        }
        
        private static string AddStaffComment(string comment, Staff staff)
        {
            var role = staff.Role == StaffRole.Responsible ? "ответственного за практику" : "человека, который подписывает практику";
            if (string.IsNullOrEmpty(staff.Email))
            {
                comment += $"Email {role}: не заполнено \n";
            }
            if (string.IsNullOrEmpty(staff.Job))
            {
                comment += $"Должность {role}: не заполнено \n";
            }
            if (string.IsNullOrEmpty(staff.Phone))
            {
                comment += $"Телефон {role}: не заполнено \n";
            }
            if (string.IsNullOrEmpty(staff.FullName))
            {
                comment += $"ФИО {role}: не заполнено \n";
            }
            
            return comment;
        }
        
        private static string AddStudentTaskComment(string comment, StudentTask studentTask)
        {
            if (string.IsNullOrEmpty(studentTask.Task))
            {
                comment += "Индивидуальное задание: не заполнено \n";
            }
            if (studentTask.Mark == 0)
            {
                comment += "Отметка за индивидуальное задание: не заполнено \n";
            }
            
            return comment;
        }
    }
}