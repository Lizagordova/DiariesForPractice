using DiariesForPractice.Domain.enums;
using DiariesForPractice.ViewModels.Interfaces;
using Reinforced.Typings.Fluent;

namespace DiariesForPractice.Configuration
{
	public class TypingsConfiguration
	{
		public static void Configure(ConfigurationBuilder builder)
		{
			builder.Global(c => c
				.UseModules()
				.CamelCaseForProperties()
				.CamelCaseForMethods()
				.AutoOptionalProperties());

			builder
				.ExportAsEnum<UserRole>()
				.OverrideNamespace("enums");
			builder
				.ExportAsEnum<InstituteEntity>()
				.OverrideNamespace("enums");
			builder
				.ExportAsEnum<StaffRole>()
				.OverrideNamespace("enums");
			builder
				.ExportAsEnum<ReportingForm>()
				.OverrideNamespace("enums");
			builder
				.ExportAsEnum<PracticeType>()
				.OverrideNamespace("enums");
			builder
				.ExportAsEnum<CommentedEntityType>()
				.OverrideNamespace("enums");
			builder
				.ExportAsEnum<AnswerType>()
				.OverrideNamespace("enums");
			builder
				.ExportAsEnum<NotificationType>()
				.OverrideNamespace("enums");

			builder
				.ExportAsInterface<IInstituteEntity>()
				.OverrideNamespace("interfaces");
		}
	}
}