using DiariesForPractice.Domain.Services.Organizations;
using DiariesForPractice.Services.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace DiariesForPractice.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationEditorService _organizationEditor;
        private readonly IOrganizationReaderService _organizationReader;
        private readonly MapperService _mapper;
        
        public OrganizationController(
            IOrganizationEditorService organizationEditor,
            IOrganizationReaderService organizationReader,
            MapperService mapper)
        {
            _organizationEditor = organizationEditor;
            _organizationReader = organizationReader;
            _mapper = mapper;
        }
    }
}