using System.Data;
using System.Linq;
using Dapper;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Persistence.DTO.Data;
using DiariesForPractice.Persistence.DTO.UDT;
using DiariesForPractice.Persistence.Extensions;
using DiariesForPractice.Persistence.Helpers;
using DiariesForPractice.Persistence.Services.MapperService;

namespace DiariesForPractice.Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private const string AddOrUpdateCommentSp = "CommentRepository_AddOrUpdateComment";
        private const string AddOrUpdateCommentGroupSp = "CommentRepository_AddOrUpdateCommentGroup";
        private const string RemoveCommentSp = "CommentRepository_RemoveComment";
        private const string GetCommentGroupSp = "CommentRepository_GetCommentGroup";
        private readonly MapperService _mapper;
        
        public CommentRepository(
            MapperService mapper)
        {
            _mapper = mapper;
        }
        
        public int AddOrUpdateComment(Comment comment, int groupId)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = CommentParam(comment, groupId);
            var commentId = conn
                .Query<int>(AddOrUpdateCommentSp, param, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            DatabaseHelper.CloseConnection(conn);

            return commentId;
        }

        public int AddOrUpdateCommentGroup(CommentGroup commentGroup)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = CommentGroupParam(commentGroup);
            var commentGroupId = conn
                .Query<int>(AddOrUpdateCommentGroupSp, param, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            DatabaseHelper.CloseConnection(conn);

            return commentGroupId;
        }

        public void RemoveComment(int commentId)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = CommentIdParam(commentId);
            conn.Query(RemoveCommentSp, param, commandType: CommandType.StoredProcedure);
            DatabaseHelper.CloseConnection(conn);
        }

        public CommentGroup GetCommentGroup(CommentGroup commentGroup)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = CommentGroupParam(commentGroup);
            var response = conn.QueryMultiple(GetCommentGroupSp, param, commandType: CommandType.StoredProcedure);
            var commentGroupData = GetCommentGroupData(response);
            commentGroup = _mapper.Map<CommentGroupData, CommentGroup>(commentGroupData);
            DatabaseHelper.CloseConnection(conn);

            return commentGroup;
        }

        private CommentGroupData GetCommentGroupData(SqlMapper.GridReader reader)
        {
            var commentGroupData = new CommentGroupData()
            {
                CommentGroup = reader.Read<CommentGroupUdt>().FirstOrDefault(),
                Comments = reader.Read<CommentUdt>().ToList()
            };

            return commentGroupData;
        }
        
        private DynamicTvpParameters CommentParam(Comment comment, int groupId)
        {
            var param = new DynamicTvpParameters();
            var tvp = new TableValuedParameter("comment", "UDT_Comment");
            var udt = _mapper.Map<Comment, CommentUdt>(comment);
            udt.GroupId = groupId;
            tvp.AddObjectAsRow(udt);
            
            return param;
        }

        private DynamicTvpParameters CommentIdParam(int commentId)
        {
            var param = new DynamicTvpParameters();
            param.Add("commentId", commentId);
            
            return param;
        }
        
        private DynamicTvpParameters CommentGroupParam(CommentGroup group)
        {
            var param = new DynamicTvpParameters();
            var tvp = new TableValuedParameter("commentGroup", "UDT_CommentGroup");
            var udt = _mapper.Map<CommentGroup, CommentGroupUdt>(group);
            tvp.AddObjectAsRow(udt);
            
            return param;
        }
    }
}