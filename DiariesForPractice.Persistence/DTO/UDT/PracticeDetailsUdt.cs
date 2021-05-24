using System;
using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.Persistence.DTO.UDT
{
	public class PracticeDetailsUdt
	{
		public int Id { get; set; }
		public int StudentId { get; set; }
		public int OrganizationId { get; set; }
		public int ReportingForm { get; set; }
		public string ContractNumber { get; set; }
		public int ResponsibleForStudent { get; set; }
		public int SignsTheContract { get; set; }
		public PracticeType PracticeType { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string StructuralDivision { get; set; }
		public string OrderOfPassingPractice { get; set; }
		public int StudentCharacteristicId { get; set; }
		public int StudentTaskId { get; set; }
	}
}