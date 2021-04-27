using System;
using System.Collections.Generic;

namespace DiariesForPractice.Domain.Models
{
	public class Degree
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IReadOnlyCollection<Course> Courses { get; set; } = Array.Empty<Course>();
	}
}