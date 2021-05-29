using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Repositories
{
    public interface ICommentRepository
    {
        int AddOrUpdateComment(Comment comment, int groupId);
        int AddOrUpdateCommentGroup(CommentGroup commentGroup);
        void RemoveComment(int commentId);
        CommentGroup GetCommentGroup(CommentGroup commentGroup);
    }
}