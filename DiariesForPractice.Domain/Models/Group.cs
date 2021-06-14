using System.Collections.Generic;

namespace DiariesForPractice.Domain.Models
{
	public class Group
	{
		public int Id { get; set; }
		public int DirectionId { get; set; }
		public int CourseId { get; set; }
		public string Name { get; set; }
		public GroupDetails GroupDetails { get; set; } = new GroupDetails();
		public List<User> Students { get; set; } = new List<User>();
	}
}