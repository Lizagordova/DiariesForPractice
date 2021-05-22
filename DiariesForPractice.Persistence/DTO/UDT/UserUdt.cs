namespace DiariesForPractice.Persistence.DTO.UDT
{
	public class UserUdt
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
		public bool EmailConfirmed { get; set; }
	}
}