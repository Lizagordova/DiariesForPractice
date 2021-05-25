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
			throw new NotImplementedException();
		}

		public PracticeDetails GetPracticeDetails(int studentId)
		{
			throw new NotImplementedException();
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