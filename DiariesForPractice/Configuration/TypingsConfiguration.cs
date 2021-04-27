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
				.ExportAsInterface<IInstituteEntity>()
				.OverrideNamespace("interfaces");
		}
	}
}