using DiariesForPractice.Configuration.Typings.Generators;
using Reinforced.Typings.Attributes;

namespace DiariesForPractice.Configuration.Typings.Attributes
{
	public class ApiViewModelAttribute : TsClassAttribute
	{
		public ApiViewModelAttribute()
		{
			Namespace = "viewModels";
			AutoExportProperties = true;
			CodeGeneratorType = typeof(ApiViewModelClassCodeGenerator);
		}
	}
}