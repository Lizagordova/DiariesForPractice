using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ReadModels
{
    [ApiReadModel]
    public class OrganizationReadModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LegalAddress { get; set; }
        public int PracticeDetailsId { get; set; }
    }
}