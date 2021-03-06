using Dapper;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Persistence.DTO.UDT;
using DiariesForPractice.Persistence.Extensions;
using DiariesForPractice.Persistence.Helpers;
using DiariesForPractice.Persistence.Services.MapperService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DiariesForPractice.Persistence.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly MapperService _mapper;
        private readonly string AddOrUpdateOrganizationSp = "OrganizationRepository_AddOrUpdateOrganization";
        private readonly string AddOrUpdateStaffSp = "OrganizationRepository_AddOrUpdateStaff";
        private readonly string GetOrganizationsSp = "OrganizationRepository_GetOrganizations";
        public OrganizationRepository(
            MapperService mapper)
        {
            _mapper = mapper;
        }

        public int AddOrUpdateOrganization(Organization organization)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = AddOrUpdateOrganizationParam(organization);
            var organizationId = conn.Query<int>(AddOrUpdateOrganizationSp, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            DatabaseHelper.CloseConnection(conn);

            return organizationId;
        }

        public int AddOrUpdateStaff(Staff staff)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = AddOrUpdateStaffParam(staff);
            var staffId = conn.Query<int>(AddOrUpdateStaffSp, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            DatabaseHelper.CloseConnection(conn);

            return staffId;
        }

        private DynamicTvpParameters AddOrUpdateStaffParam(Staff staff)
        {
            var param = new DynamicTvpParameters();
            var tvp = new TableValuedParameter("staff", "UDT_Staff");
            var udt = _mapper.Map<Staff, StaffUdt>(staff);
            tvp.AddObjectAsRow(udt);
            param.Add(tvp);

            return param;
        }

        private DynamicTvpParameters AddOrUpdateOrganizationParam(Organization organization)
        {
            var param = new DynamicTvpParameters();
            var tvp = new TableValuedParameter("organization", "UDT_Organization");
            var udt = _mapper.Map<Organization, OrganizationUdt>(organization);
            tvp.AddObjectAsRow(udt);
            param.Add(tvp);

            return param;
        }

        public IReadOnlyCollection<Organization> GetOrganizations()//TODO: Возможно, здесь ещё нужно и стафф подтягивать и ещё что то
        {
            var conn = DatabaseHelper.OpenConnection();
            var organizationUdts = conn.Query<OrganizationUdt>(GetOrganizationsSp, commandType: CommandType.StoredProcedure);
            var organizations = organizationUdts.Select(_mapper.Map<OrganizationUdt, Organization>).ToList();
            DatabaseHelper.CloseConnection(conn);

            return organizations;
        }
    }
}
