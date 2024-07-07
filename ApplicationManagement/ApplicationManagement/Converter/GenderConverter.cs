using System;
using System.Globalization;
using System.Windows.Data;

namespace ApplicationManagement.Converter {
    public class GenderConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            string gender = value as string;

            if (gender == "M") {
                return "Male";
            }
            else if (gender == "F") {
                return "Female";
            }

            return gender;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            string genderString = value as string;

            if (genderString == "Male") {
                return "M";
            }
            else if (genderString == "Female") {
                return "F";
            }

            return genderString;
        }
    }
}
