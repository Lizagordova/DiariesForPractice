using System;
using System.Collections.Generic;
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ReadModels
{
	[ApiReadModel]
	public class CafedraReadModel
	{
		public int Id { get; set; }
		public int InstituteId { get; set; }
		public string Name { get; set; }
		public IReadOnlyCollection<DirectionReadModel> Directions { get; set; } = Array.Empty<DirectionReadModel>();
	}
}