using System;
using DiariesForPractice.Configuration.Typings.Attributes;
using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.ReadModels
{
    [ApiReadModel]
    public class PracticeReadModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public OrganizationReadModel Organization { get; set; }
        public ReportingForm ReportingForm { get; set; }
        public string ContractNumber { get; set; }
        public StaffReadModel ResponsibleForStudent { get; set; }
        public StaffReadModel SignsTheContract { get; set; }
        public PracticeType PracticeType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StructuralDivision { get; set; }
        public string OrderId { get; set; }
        public CalendarPlanReadModel CalendarPlan { get; set; }
        public StudentCharacteristicReadModel StudentCharacteristic { get; set; }
        public StudentTaskReadModel StudentTask { get; set; }
    }
}