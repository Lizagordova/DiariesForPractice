using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels
{
    [ApiViewModel]
    public class OrganizationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LegalAddress { get; set; }
    }
}