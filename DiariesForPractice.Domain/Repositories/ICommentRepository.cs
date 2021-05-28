using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Repositories
{
    public interface ICommentRepository
    {
        int AddOrUpdateComment(Comment comment);
        int AddOrUpdateCommentGroup(CommentGroup commentGroup);
        CommentGroup GetCommentGroup();
    }
}