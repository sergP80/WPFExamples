using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace SharedResources
{
    public class ImageSourceFromUriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Uri imageUri = null;
            if (value is string)
            {
                imageUri = new Uri((string)value);
            } else if (value is Uri)
            {
                imageUri = (Uri)value;
            }
            if (imageUri == null)
            {
                throw new ArgumentException("Invalid Uri source value");
            }
            return new BitmapImage(imageUri);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is BitmapImage)
            {
                return ((BitmapImage)value).UriSource;
            }
            throw new ArgumentException("Can't find Uri in image source");
        }
    }
}
