using System;
using System.Collections.Generic;
using DiariesForPractice.Persistence.DTO.UDT;

namespace DiariesForPractice.Persistence.DTO.Data
{
    public class CommentGroupData
    {
        public CommentGroupUdt CommentGroup { get; set; }
        public IReadOnlyCollection<CommentUdt> Comments { get; set; } = Array.Empty<CommentUdt>();
    }
}