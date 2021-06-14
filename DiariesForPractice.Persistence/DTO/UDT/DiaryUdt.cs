using System;

namespace DiariesForPractice.Persistence.DTO.UDT
{
	public class DiaryUdt
	{
		public int Id { get; set; }
		public int StudentId { get; set; }
		public string Path { get; set; }
		public bool Generated { get; set; }
		public bool Send { get; set; }
		public bool Approved { get; set; }
		public bool Perceived { get; set; }
		public DateTime GeneratedDate { get; set; }
		public DateTime SendDate { get; set; }
		public DateTime PerceivedDate { get; set; }
		public int Completion { get; set; }
		public string Comment { get; set; }
		public bool DirectorSigned { get; set; }
		public bool CafedraHeadSigned { get; set; }
	}
}