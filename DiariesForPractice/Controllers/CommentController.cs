using System;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services.Comments;
using DiariesForPractice.Helpers;
using DiariesForPractice.ReadModels;
using DiariesForPractice.Services;
using DiariesForPractice.Services.Mapper;
using DiariesForPractice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiariesForPractice.Controllers
{
    public class CommentController : Controller
    {
        private readonly MapperService _mapper;
        private readonly ILogger<CommentController> _logger;
        private readonly LogService _logService;
        private readonly ICommentEditorService _commentEditor;
        private readonly ICommentReaderService _commentReader;
        private readonly MapHelper _mapHelper;
        
        public CommentController(
            MapperService mapper,
            ILogger<CommentController> logger,
            LogService logService,
            ICommentEditorService commentEditor,
            ICommentReaderService commentReader,
            MapHelper mapHelper)
        {
            _mapper = mapper;
            _logger = logger;
            _logService = logService;
            _commentEditor = commentEditor;
            _commentReader = commentReader;
            _mapHelper = mapHelper;
        }
        
        [HttpPost]
        [Route("/addorupdatecomment")]
        public ActionResult AddOrUpdateComment([FromBody]CommentReadModel commentReadModel)
        {
            try
            {
                var comment = _mapper.Map<CommentReadModel, Comment>(commentReadModel);
                var commentId =  _commentEditor.AddOrUpdateComment(comment, commentReadModel.GroupId);
				
                return new JsonResult(commentId);
            }
            catch (Exception e)
            {
                _logService.AddOrUpdateCommentLog(_logger, e, LogType.Base, commentReadModel.UserId, commentReadModel.Id, commentReadModel.GroupId);

                return new StatusCodeResult(500);
            }
        }
        
        [HttpPost]
        [Route("/addorupdatecommentgroup")]
        public ActionResult AddOrUpdateCommentGroup([FromBody]CommentGroupReadModel commentGroupReadModel)
        {
            var commentGroup = _mapHelper.MapCommentGroup(commentGroupReadModel);
            try
            {
                var commentGroupId = _commentEditor.AddOrUpdateCommentGroup(commentGroup);
				
                return new JsonResult(commentGroupId);
            }
            catch (Exception e)
            {
                _logService.AddOrUpdateCommentGroup(_logger, e, LogType.Base, commentGroup);

                return new StatusCodeResult(500);
            }
        }
        
        [HttpPost]
        [Route("/removecomment")]
        public ActionResult RemoveComment([FromBody]CommentReadModel commentReadModel)
        {
            try
            {
                _commentEditor.RemoveComment(commentReadModel.Id);
				
                return new OkResult();
            }
            catch (Exception e)
            {
                _logService.RemoveCommentLog(_logger, e, LogType.Base, commentReadModel.Id);

                return new StatusCodeResult(500);
            }
        }
        
        [HttpPost]
        [Route("/getcommentgroup")]
        public ActionResult GetCommentGroup([FromBody]CommentGroupReadModel commentGroupReadModel)
        {
            var commentGroup = _mapHelper.MapCommentGroup(commentGroupReadModel);
            try
            {
                var perceivedCommentGroup = _commentReader.GetCommentGroup(commentGroup);
                var commentGroupViewModel = _mapHelper.MapCommentGroupViewModel(perceivedCommentGroup);
				
                return new JsonResult(commentGroupViewModel);
            }
            catch (Exception e)
            {
                _logService.GetCommentGroupLog(_logger, e, LogType.Base, commentGroup);

                return new StatusCodeResult(500);
            }
        }
    }
}