using System;
using System.Globalization;
using System.IO;
using System.Net;
using Xamarin.Forms;

namespace VolcanoFinder.Converters
{

    /// <summary>
    /// This is needed for iOS as using HotRestart fails to load the image due to a bug in the FFImageLoading that clashes with the way that
    /// HotRestart works.
    /// Issue - https://github.com/luberda-molinet/FFImageLoading/issues/1432
    /// </summary>
    public class SourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Device.RuntimePlatform == Device.Android)
                return value;

            if (value != null)
                return ImageSource.FromStream(() => new MemoryStream(new WebClient().DownloadData(value.ToString())));

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
