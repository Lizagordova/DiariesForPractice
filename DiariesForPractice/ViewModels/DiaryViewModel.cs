using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels
{
	[ApiViewModel]
	public class DiaryViewModel
	{
		public int Id { get; set; }
		public string Path { get; set; }
		public bool Generated { get; set; }
		public bool Send { get; set; }
		public int StudentId { get; set; }
		public string Comment { get; set; }
	}
}