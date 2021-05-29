using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.Comments
{
    public interface ICommentReaderService
    {
        CommentGroup GetCommentGroup(CommentGroup group);
    }
}