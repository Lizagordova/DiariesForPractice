using DiariesForPractice.Domain.Services.Comments;
using DiariesForPractice.Services;
using DiariesForPractice.Services.Mapper;
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
        
        public CommentController(
            MapperService mapper,
            ILogger<CommentController> logger,
            LogService logService)
        {
            _mapper = mapper;
            _logger = logger;
            _logService = logService;
        }
    }
}