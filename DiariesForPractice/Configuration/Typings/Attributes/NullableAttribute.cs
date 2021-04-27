using Reinforced.Typings.Attributes;

namespace DiariesForPractice.Configuration.Typings.Attributes
{
	public class NullableAttribute : TsPropertyAttribute
	{
		public NullableAttribute()
		{
			ForceNullable = true;
		}
	}
}