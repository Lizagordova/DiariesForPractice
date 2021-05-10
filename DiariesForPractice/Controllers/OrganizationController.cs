using DiariesForPractice.Domain.Services.Organizations;
using DiariesForPractice.Services;
using DiariesForPractice.Services.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiariesForPractice.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationEditorService _organizationEditor;
        private readonly IOrganizationReaderService _organizationReader;
        private readonly MapperService _mapper;
        private readonly ILogger<OrganizationController> _logger;
        private readonly LogService _logService;

        public OrganizationController(
            IOrganizationEditorService organizationEditor,
            IOrganizationReaderService organizationReader,
            MapperService mapper,
            ILogger<OrganizationController> logger,
            LogService logService)
        {
            _organizationEditor = organizationEditor;
            _organizationReader = organizationReader;
            _mapper = mapper;
            _logger = logger;
            _logService = logService;
        }
    }
}