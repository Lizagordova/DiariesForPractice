namespace DiariesForPractice.Persistence.DTO.UDT
{
    public class CommentGroupUdt
    {
        public int Id { get; set; }
        public int CommentedEntityType { get; set; }
        public int CommentedEntityId { get; set; }
        public int UserId { get; set; } 
    }
}