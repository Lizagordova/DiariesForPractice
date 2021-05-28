using System;
using System.Collections.Generic;

namespace DiariesForPractice.Domain.Models
{
    public class CommentGroup
    {
        public int Id { get; set; }
        public int CommentedEntityType { get; set; }
        public int CommentedEntityId { get; set; }
        public int UserId { get; set; }
        public IReadOnlyCollection<Comment> Comments { get; set; } = Array.Empty<Comment>();
    }
}