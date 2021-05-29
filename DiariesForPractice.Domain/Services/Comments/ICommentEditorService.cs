using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.Comments
{
    public interface ICommentEditorService
    {
        int AddOrUpdateComment(Comment comment, int groupId);
        int AddOrUpdateCommentGroup(CommentGroup commentGroup);
        void RemoveComment(int commentId);

    }
}