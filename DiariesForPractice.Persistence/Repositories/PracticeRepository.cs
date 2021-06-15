using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Persistence.DTO.UDT;
using DiariesForPractice.Persistence.Extensions;
using DiariesForPractice.Persistence.Helpers;
using DiariesForPractice.Persistence.Services.MapperService;

namespace DiariesForPractice.Persistence.Repositories
{
	public class PracticeRepository : IPracticeRepository
	{
		private readonly MapperService _mapper;
		private const string AddOrUpdatePracticeDetailsSp = "PracticeRepository_AddOrUpdatePracticeDetails";
		private const string GetPracticeDetailsSp = "PracticeRepository_GetPracticeDetails";
		private const string AttachDataToPracticeDetailsSp = "PracticeRepository_AttachDataToPracticeDetails";

		public PracticeRepository(
			MapperService mapper)
		{
			_mapper = mapper;
		}

		public int AddOrUpdatePracticeDetails(PracticeDetails practiceDetails)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetAddOrUpdatePracticeDetailsParam(practiceDetails);
			var practiceDetailsId =
				conn.Query<int>(AddOrUpdatePracticeDetailsSp, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
			DatabaseHelper.CloseConnection(conn);

			return practiceDetailsId;
		}

		public IReadOnlyCollection<PracticeDetails> GetPracticeDetails(PracticeDetailsQuery query)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetPracticeDetailsParam(query);
			var practiceDetailUdts = conn.Query<PracticeDetailsUdt>(GetPracticeDetailsSp, param, commandType: CommandType.StoredProcedure).ToList();
			var practiceDetails = practiceDetailUdts.Select(_mapper.Map<PracticeDetailsUdt, PracticeDetails>).ToList();
			DatabaseHelper.CloseConnection(conn);

			return practiceDetails;
		}

		public void AttachDataToPracticeDetails(int dataId, int practiceDetailsId, PracticeDetailsDataType type)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetDataPracticeParam(dataId, practiceDetailsId, type);
			conn.Query(AttachDataToPracticeDetailsSp, param, commandType: CommandType.StoredProcedure);
			DatabaseHelper.CloseConnection(conn);
		}

		private DynamicTvpParameters GetDataPracticeParam(int dataId, int practiceDetailsId, PracticeDetailsDataType type)
		{
			var param = new DynamicTvpParameters();
			param.Add("practiceDetailsId", practiceDetailsId);
			if (type == PracticeDetailsDataType.Organization)
			{
				param.Add("organizationId", dataId);
			}
			if (type == PracticeDetailsDataType.ResponsibleForStudent)
			{
				param.Add("responsibleForStudentId", dataId);
			}
			if (type == PracticeDetailsDataType.SignsTheContract)
			{
				param.Add("signsTheContractId", dataId);
			}
			if (type == PracticeDetailsDataType.StudentCharacteristic)
			{
				param.Add("studentCharacteristicId", dataId);
			}
			if (type == PracticeDetailsDataType.StudentTask)
			{
				param.Add("studentTaskId", dataId);
			}
			return param;
		}
		
		public PracticeDetails GetPracticeDetails(int studentId)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetPracticeDetailsParam(new PracticeDetailsQuery() {StudentId = studentId});
			var practiceDetailsUdt = conn
				.Query <PracticeDetailsUdt>(GetPracticeDetailsSp, param, commandType: CommandType.StoredProcedure)
				.FirstOrDefault();
			var practiceDetails = _mapper.Map<PracticeDetailsUdt, PracticeDetails>(practiceDetailsUdt);
			DatabaseHelper.CloseConnection(conn);

			return practiceDetails;
		}

		private DynamicTvpParameters GetAddOrUpdatePracticeDetailsParam(PracticeDetails practiceDetails)
		{
			var param = new DynamicTvpParameters();
			var tvp = new TableValuedParameter("practiceDetails", "UDT_PracticeDetails");
			var udt = _mapper.Map<PracticeDetails, PracticeDetailsUdt>(practiceDetails);
			tvp.AddObjectAsRow(udt);
			param.Add(tvp);

			return param;
		}

		private DynamicTvpParameters GetPracticeDetailsParam(PracticeDetailsQuery query)
		{
			var param = new DynamicTvpParameters();
			param.Add("groupId", query.GroupId);
			param.Add("studentId", query.StudentId);

			return param;
		}
	}
}