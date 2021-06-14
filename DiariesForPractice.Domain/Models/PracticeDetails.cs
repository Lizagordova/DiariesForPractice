using System;
using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.Domain.Models
{
	public class PracticeDetails
	{
		public int Id { get; set; }
		public User Student { get; set; }
		public Organization Organization { get; set; }
		public ReportingForm ReportingForm { get; set; }
		public string ContractNumber { get; set; }
		public Staff ResponsibleForStudent { get; set; }
		public Staff SignsTheContract { get; set; }
		public PracticeType PracticeType { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string StructuralDivision { get; set; }
		public Order Order { get; set; }
		public CalendarPlan CalendarPlan { get; set; }
		public StudentCharacteristic StudentCharacteristic { get; set; }
		public StudentTask StudentTask { get; set; }
	}
}