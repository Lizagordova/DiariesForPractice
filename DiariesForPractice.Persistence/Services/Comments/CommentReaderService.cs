using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.Comments;

namespace DiariesForPractice.Persistence.Services.Comments
{
    public class CommentReaderService : ICommentReaderService
    {
        private readonly ICommentRepository _commentRepository;
        
        public CommentReaderService(
            ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        
        public CommentGroup GetCommentGroup(CommentGroup group)
        {
            var commentGroup = _commentRepository.GetCommentGroup(group);

            return commentGroup;
        }
    }
}