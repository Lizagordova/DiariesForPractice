﻿using System.Collections.Generic;
using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.Domain.Models
{
	public class User
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Token { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string EmailConfirmed { get; set; }
		public List<UserRole> Roles { get; set; }
		public string FullName => $"{FirstName} {SecondName} {LastName}";
	}
}