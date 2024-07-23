using System.Globalization;

namespace IndirimOranTutarHesapla.Converter
{
    public class ZeroToEmptyStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (IsDoubleZero(value))
                return string.Empty;
            return FormatDouble(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value as string))
                return 0;
            if (double.TryParse(value as string, out double result))
                return KontrolluYuvarla(result, 1); // Bir ondalık basamağa yuvarla
            return value;
        }

        private bool IsDoubleZero(object value)
        {
            return value is double doubleValue && Math.Abs(doubleValue) < 0.0001; // 0'a yakın olan değerleri de kabul et
        }

        private string FormatDouble(object value)
        {
            if (value is double doubleValue)
            {
                if (Math.Abs(doubleValue % 1) < 0.0001)
                {
                    return ((int)doubleValue).ToString(); // Tamsayı ise ondalık basamak eklemeden stringe çevir
                }
                else
                {
                    return KontrolluYuvarla(doubleValue, 1).ToString("F1", CultureInfo.InvariantCulture); // Ondalık basamaklı ise bir ondalık basamağa yuvarla ve stringe çevir
                }
            }
            return value?.ToString();
        }
        public static double KontrolluYuvarla(double matrah, int kurushanesi)
        {
            double result = matrah;
            result *= Math.Pow(10, kurushanesi);
            result = Math.Round(result, kurushanesi);
            result = Math.Round(result, 0, MidpointRounding.AwayFromZero);
            result *= Math.Pow(10, -1 * kurushanesi);
            return result;
        }
    }
}
