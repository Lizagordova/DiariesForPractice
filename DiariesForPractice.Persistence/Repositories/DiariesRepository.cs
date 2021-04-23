using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Persistence.DTO.UDT;
using DiariesForPractice.Persistence.Extensions;
using DiariesForPractice.Persistence.Helpers;
using DiariesForPractice.Persistence.Services.MapperService;

namespace DiariesForPractice.Persistence.Repositories
{
	public class DiariesRepository : IDiariesRepository
	{
		private readonly MapperService _mapper;
		private const string AddOrUpdateDiarySp = "DiariesRepository_AddOrUpdateDiary";
		private const string GetDiariesSp = "DiariesRepository_GetDiaries";
		public DiariesRepository(
			MapperService mapper)
		{
			_mapper = mapper;
		}

		public int AddOrUpdateDiary(Diary diary)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetAddOrUpdateDiaryParam(diary);
			var diaryId = conn.Query<int>(AddOrUpdateDiarySp, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
			DatabaseHelper.CloseConnection(conn);

			return diaryId;
		}

		public IReadOnlyCollection<Diary> GetDiaries()
		{
			var conn = DatabaseHelper.OpenConnection();
			var diaryUdts = conn.Query<DiaryUdt>(GetDiariesSp, commandType: CommandType.StoredProcedure).ToList();
			var diaries = diaryUdts.Select(_mapper.Map<DiaryUdt, Diary>).ToList();
			DatabaseHelper.CloseConnection(conn);

			return diaries;
		}

		private DynamicTvpParameters GetAddOrUpdateDiaryParam(Diary diary)
		{
			var param = new DynamicTvpParameters();
			var tvp = new TableValuedParameter("diary", "UDT_Diary");
			var udt = _mapper.Map<Diary, DiaryUdt>(diary);
			tvp.AddObjectAsRow(udt);
			param.Add(tvp);

			return param;
		}
	}
}