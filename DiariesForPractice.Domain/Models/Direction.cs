using System;
using System.Collections.Generic;

namespace DiariesForPractice.Domain.Models
{
	public class Direction
	{
		public int Id { get; set; }
		public int CafedraId { get; set; }
		public string Name { get; set; }
		public string Number { get; set; }
		public IReadOnlyCollection<Group> Groups { get; set; } = Array.Empty<Group>();
	}
}