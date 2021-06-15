using System;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services.Organizations;
using DiariesForPractice.ReadModels;
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

        [HttpPost]
        [Route("/addorupdateorganization")]
        public ActionResult AddOrUpdateOrganization([FromBody]OrganizationReadModel organizationReadModel)
        {
            try
            {
                var organization = _mapper.Map<OrganizationReadModel, Organization>(organizationReadModel);
                var organizationId = _organizationEditor.AddOrUpdateOrganization(organization, organizationReadModel.PracticeDetailsId);

                return new JsonResult(organizationId);
            }
            catch (Exception e)
            {
                _logService.AddOrUpdateOrganizationLog(_logger, e, LogType.Base);
                
                return new StatusCodeResult(500);
            }
        }
        
        [HttpPost]
        [Route("/addorupdatestaff")]
        public ActionResult AddOrUpdateStaff([FromBody]StaffReadModel staffReadModel)
        {
            try
            {
                var staff = _mapper.Map<StaffReadModel, Staff>(staffReadModel);
                var staffId = _organizationEditor.AddOrUpdateStaff(staff, staffReadModel.PracticeDetailsId);

                return new JsonResult(staffId);
            }
            catch (Exception e)
            {
                _logService.AddOrUpdateStaffLog(_logger, e, LogType.Base);
                
                return new StatusCodeResult(500);
            }
        }
    }
}