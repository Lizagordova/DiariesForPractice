﻿using System.Collections.Generic;

namespace DiariesForPractice.Domain.Models
{
	public class Group
	{
		public int Id { get; set; }
		public int InstituteId { get; set; }
		public int CafedraId { get; set; }
		public int DirectionId { get; set; }
		public int CourseId { get; set; }
		public string Name { get; set; }
		public GroupDetails GroupDetails { get; set; }
		public IReadOnlyCollection<User> Students { get; set; }
	}
}