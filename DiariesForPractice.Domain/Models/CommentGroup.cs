using System;
using System.Collections.Generic;
using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.Domain.Models
{
    public class CommentGroup
    {
        public int Id { get; set; }
        public CommentedEntityType CommentedEntityType { get; set; }
        public int CommentedEntityId { get; set; }
        public int UserId { get; set; }
        public IReadOnlyCollection<Comment> Comments { get; set; } = Array.Empty<Comment>();
    }
}