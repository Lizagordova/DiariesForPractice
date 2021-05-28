namespace DiariesForPractice.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int CommentedEntityType { get; set; }
        public int CommentedEntityId { get; set; }
        public int UserId { get; set; } 
    }
}