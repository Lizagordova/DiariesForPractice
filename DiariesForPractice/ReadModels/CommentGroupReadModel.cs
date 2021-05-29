using DiariesForPractice.Configuration.Typings.Attributes;
using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.ReadModels
{
    [ApiReadModel]
    public class CommentGroupReadModel
    {
        public int Id { get; set; }
        public CommentedEntityType CommentedEntityType { get; set; }
        public int CommentedEntityId { get; set; }
        public int UserId { get; set; }
        public CommentReadModel Comment { get; set; } = new CommentReadModel();

    }
}