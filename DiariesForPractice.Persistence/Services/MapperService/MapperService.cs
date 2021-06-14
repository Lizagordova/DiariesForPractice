﻿using DiariesForPractice.Domain.Services;

namespace DiariesForPractice.Persistence.Services.MapperService
{
	public partial class MapperService : MapperServiceBase
	{
		protected override void CreateMappings()
		{
			CreateDiariesMappings();
			CreateCommentMappings();
			CreateInstituteDetailsMappings();
			CreateLogMappings();
			CreateNotificationMappings();
			CreateOrganizationMappings();
			CreatePracticeDetailsMappings();
			CreateStudentCharacteristicsMappings();
			CreateStudentTasksMappings();
			CreateUsersMappings();
		}
	}
}