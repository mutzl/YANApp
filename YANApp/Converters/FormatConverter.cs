namespace YANApp.Converters
{
	using System;
	using System.Globalization;

	using Windows.UI.Xaml.Data;
	public class FormatConverter : IValueConverter
	{
		public string Format { get; set; }
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			string format;
			if (Format != null)
			{
				format = Format;
			}
			else
			{
				format = parameter as string;
			}
			if (format == null) return value;


			var culture = string.IsNullOrEmpty(language) ? CultureInfo.InvariantCulture : new CultureInfo(language);

			if (value is int) return ((int)value).ToString(format, culture);
			if (value is long) return ((long)value).ToString(format, culture);
			if (value is double) return ((double)value).ToString(format, culture);
			if (value is float) return ((float)value).ToString(format, culture);
			if (value is decimal) return ((decimal)value).ToString(format, culture);
			if (value is DateTime) return ((DateTime)value).ToString(format, culture);
			if (value is TimeSpan) return ((TimeSpan)value).ToString(format, culture);

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
