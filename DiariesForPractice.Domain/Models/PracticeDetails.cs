using System;
using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.Domain.Models
{
	public class PracticeDetails
	{
		public int Id { get; set; }
		public User Student { get; set; } = new User();
		public Organization Organization { get; set; } = new Organization();
		public ReportingForm ReportingForm { get; set; } = ReportingForm.None;
		public string ContractNumber { get; set; }
		public Staff ResponsibleForStudent { get; set; } = new Staff();
		public Staff SignsTheContract { get; set; } = new Staff();
		public PracticeType PracticeType { get; set; }
		public DateTime StartDate { get; set; } = DateTime.Now;
		public DateTime EndDate { get; set; } = DateTime.Now;
		public string StructuralDivision { get; set; }
		public Order Order { get; set; } = new Order();
		public CalendarPlan CalendarPlan { get; set; } = new CalendarPlan();
		public StudentCharacteristic StudentCharacteristic { get; set; } = new StudentCharacteristic();
		public StudentTask StudentTask { get; set; } = new StudentTask();
	}
}