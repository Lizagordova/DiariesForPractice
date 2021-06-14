using System;
using System.Collections.Generic;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Persistence.Repositories;
using DiariesForPractice.Persistence.Services.Authorization;
using DiariesForPractice.Persistence.Services.Comments;
using DiariesForPractice.Persistence.Services.MapperService;
using NUnit.Framework;

namespace DiariesForPractice.Tests.Services
{
    public class CommentServiceTests
    {
        private readonly CommentEditorService _commentEditor;
        private readonly CommentReaderService _commentReader;
        
        public CommentServiceTests()
        {
            var mapper = new MapperService();
            var commentRepository = new CommentRepository(mapper);
            _commentEditor = new CommentEditorService(commentRepository);
            _commentReader = new CommentReaderService(commentRepository);
        }
        
        [Test]
        public void AddOrUpdateCommentGroup_Test()
        {
            var comments = new List<Comment>();
            comments.Add(new Comment() { UserId = 1, PublishDate = DateTime.Now, Text = "Привет!"});
            var commentGroup = new CommentGroup()
            {
                CommentedEntityType = CommentedEntityType.Diary,
                UserId = 1,
                CommentedEntityId = 1,
                Comments = comments
            };
            var groupId = _commentEditor.AddOrUpdateCommentGroup(commentGroup);
            var result = groupId != 0;
            Console.WriteLine($"groupId={groupId}");
            Assert.That(result == true);
        }
        
        [Test]
        public void RemoveComment_Test()
        {
            _commentEditor.RemoveComment(1);
        }
        
        [Test]
        public void GetCommentGroup_Test()
        {
            var commentGroup = new CommentGroup()
            {
                CommentedEntityType = CommentedEntityType.Diary,
                UserId = 1,
                CommentedEntityId = 1
            };
            var group = _commentReader.GetCommentGroup(commentGroup);
            Console.WriteLine($"gr={group.Id}; UserId={group.UserId}; CommentedEntityId={group.CommentedEntityId}; CommentedEntityType={group.CommentedEntityType}");
        }
    }
}