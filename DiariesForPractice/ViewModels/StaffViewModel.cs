using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels
{
    [ApiViewModel]
    public class StaffViewModel
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string FullName { get; set; }
        public string Job { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}