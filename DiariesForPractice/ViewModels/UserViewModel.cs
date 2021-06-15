using System.Collections.Generic;
using DiariesForPractice.Configuration.Typings.Attributes;
using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.ViewModels
{
	[ApiViewModel]
	public class UserViewModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string LastName { get; set; }

		public string FIO => $"{FirstName} {SecondName} {LastName}";
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Token { get; set; }
		public UserRole Role { get; set; }
	}
}