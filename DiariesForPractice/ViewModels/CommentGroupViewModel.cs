using System;
using System.Collections.Generic;
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels
{
    [ApiViewModel]
    public class CommentGroupViewModel
    {
        public int Id { get; set; }
        public int CommentedEntityType { get; set; }
        public int CommentedEntityId { get; set; }
        public int UserId { get; set; }
        public IReadOnlyCollection<CommentViewModel> Comments { get; set; } = Array.Empty<CommentViewModel>();
    }
}