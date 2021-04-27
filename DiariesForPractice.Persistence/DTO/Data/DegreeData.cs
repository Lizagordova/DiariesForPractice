using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Persistence.DTO.UDT;

namespace DiariesForPractice.Persistence.DTO.Data
{
	public class DegreeData
	{
		public List<DegreeUdt> Degrees { get; set; }
		public List<CourseUdt> Courses { get; set; }
	}
}