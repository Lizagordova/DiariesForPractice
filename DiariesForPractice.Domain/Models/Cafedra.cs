using System;
using System.Collections.Generic;

namespace DiariesForPractice.Domain.Models
{
	public class Cafedra
	{
		public int Id { get; set; }
		public int InstituteId { get; set; }
		public string Name { get; set; }
		public IReadOnlyCollection<Direction> Directions { get; set; } = Array.Empty<Direction>();
	}
}