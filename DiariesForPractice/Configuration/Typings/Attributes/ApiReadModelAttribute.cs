using Reinforced.Typings.Attributes;

namespace DiariesForPractice.Configuration.Typings.Attributes
{
	public class ApiReadModelAttribute : TsClassAttribute
	{
		public ApiReadModelAttribute()
		{
			Namespace = "readModels";
			AutoExportMethods = true;
		}
	}
}