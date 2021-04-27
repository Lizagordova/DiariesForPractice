using System;
using System.Collections.Generic;
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ReadModels
{
	[ApiReadModel]
	public class DirectionReadModel
	{
		public int Id { get; set; }
		public int CafedraId { get; set; }
		public string Name { get; set; }
		public IReadOnlyCollection<GroupReadModel> Groups { get; set; } = Array.Empty<GroupReadModel>();
	}
}