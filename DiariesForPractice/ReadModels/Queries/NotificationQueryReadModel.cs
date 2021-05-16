using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ReadModels.Queries
{
    [ApiReadModel]
    public class NotificationQueryReadModel
    {
        public int? UserForId { get; set; }
        public bool? Watched { get; set; }
    }
}