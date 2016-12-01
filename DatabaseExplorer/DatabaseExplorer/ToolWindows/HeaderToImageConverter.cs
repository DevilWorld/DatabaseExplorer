using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using DatabaseExplorer.ToolWindows.ViewModel;

namespace DatabaseExplorer.ToolWindows
{
    [ValueConversion(typeof(string), typeof(bool))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DbObjectViewModel)
            {
                DbObjectViewModel tvm = (DbObjectViewModel)value;

                Uri uri = null;
                switch (tvm.NodeType)
                {
                    case Enums.NodeType.Table:
                        uri = new Uri("pack://application:,,,/DatabaseExplorer;component/images/table2.png");
                        break;
                    case Enums.NodeType.Column:
                        uri = new Uri("pack://application:,,,/DatabaseExplorer;component/images/columns.png");
                        break;
                    default:
                        break;
                }

                if (uri == null) return null;

                BitmapImage source = new BitmapImage(uri);
                return source;

            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}
