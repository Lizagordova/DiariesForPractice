using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Persistence.DTO.UDT;
using DiariesForPractice.Persistence.Extensions;
using DiariesForPractice.Persistence.Helpers;
using DiariesForPractice.Persistence.Services.MapperService;

namespace DiariesForPractice.Persistence.Repositories
{
	public class GoogleDetailsRepository : IGoogleDetailsRepository
	{
		private readonly MapperService _mapper;
		private const string AddOrUpdateGoogleDetailsSp = "GoogleDetailsRepository_AddOrUpdateGoogleDetails";
		private const string GetGoogleDetailsSp = "GoogleDetailsRepository_GetGoogleDetails";
		public GoogleDetailsRepository(
			MapperService mapper)
		{
			_mapper = mapper;
		}

		public int AddOrUpdateGoogleDetails(GoogleDetails googleDetails)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = AddOrUpdateGoogleDetailsParam(googleDetails);
			var googleDetailsId = conn.Query<int>(AddOrUpdateGoogleDetailsSp, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
			DatabaseHelper.CloseConnection(conn);

			return googleDetailsId;
		}

		public IReadOnlyCollection<GoogleDetails> GetGoogleDetails(GoogleDetailsQuery query)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetGoogleDetailsParam(query);
			var googleDetailsUdt = conn.Query<GoogleDetailsUdt>(GetGoogleDetailsSp, param, commandType: CommandType.StoredProcedure);
			var googleDetails = googleDetailsUdt.Select(_mapper.Map<GoogleDetailsUdt, GoogleDetails>).ToList();
			DatabaseHelper.CloseConnection(conn);

			return googleDetails;
		}
		
		private DynamicTvpParameters GetGoogleDetailsParam(GoogleDetailsQuery query)
		{
			var param = new DynamicTvpParameters();
			param.Add("groupId", query.GroupId);

			return param;
		}

		private DynamicTvpParameters AddOrUpdateGoogleDetailsParam(GoogleDetails googleDetails)
		{
			var param = new DynamicTvpParameters();
			var tvp = new TableValuedParameter("googleDetails", "UDT_GoogleDetails");
			var udt = _mapper.Map<GoogleDetails, GoogleDetailsUdt>(googleDetails);
			tvp.AddObjectAsRow(udt);
			param.Add(tvp);

			return param;
		}
	}
}