using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.Comments;

namespace DiariesForPractice.Persistence.Services.Comments
{
    public class CommentEditorService : ICommentEditorService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentEditorService(
            ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        
        public int AddOrUpdateComment(Comment comment, int groupId)
        {
            var commentId = _commentRepository.AddOrUpdateComment(comment, groupId);

            return commentId;
        }

        public int AddOrUpdateCommentGroup(CommentGroup commentGroup)
        {
            var commentGroupId = _commentRepository.AddOrUpdateCommentGroup(commentGroup);
            foreach (var comment in commentGroup.Comments)
            {
                comment.Id = _commentRepository.AddOrUpdateComment(comment, commentGroupId);
            }

            return commentGroupId;
        }

        public void RemoveComment(int commentId)
        {
            _commentRepository.RemoveComment(commentId);
        }
    }
}