using System;
using System.Collections.Generic;

namespace DiariesForPractice.Domain.Models
{
	public class Institute
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IReadOnlyCollection<Cafedra> Cafedras { get; set; } = Array.Empty<Cafedra>();
	}
}