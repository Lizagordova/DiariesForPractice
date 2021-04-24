using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels.Interfaces
{
	public interface IInstituteEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}