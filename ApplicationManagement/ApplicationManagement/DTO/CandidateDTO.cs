using System;
using System.ComponentModel;

namespace ApplicationManagement.DTO {
    public class CandidateDTO : INotifyPropertyChanged, ICloneable {

        public string CandidateName { get; set; }
        public string CCCD { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone() {
            return MemberwiseClone();
        }

        // IDataErrorInfo Members
        public string Error => null;

        public string this[string columnName] {
            get {
                string result = null;
                switch (columnName) {
                    case nameof(CandidateName):
                        if (string.IsNullOrWhiteSpace(CandidateName)) {
                            result = "Name cannot be empty.";
                        }
                        break;
                    case nameof(CCCD):
                        if (string.IsNullOrWhiteSpace(CCCD)) {
                            result = "CCCD cannot be empty.";
                        }
                        break;
                    case nameof(Gender):
                        if (string.IsNullOrWhiteSpace(Gender)) {
                            result = "Gender must be selected.";
                        }
                        break;
                    case nameof(PhoneNumber):
                        if (string.IsNullOrWhiteSpace(PhoneNumber)) {
                            result = "Phone number cannot be empty.";
                        }
                        else if (!System.Text.RegularExpressions.Regex.IsMatch(PhoneNumber, @"^\d{10}$")) {
                            result = "Phone number must be 10 digits.";
                        }
                        break;
                    case nameof(DateOfBirth):
                        if (string.IsNullOrWhiteSpace(DateOfBirth)) {
                            result = "Date of birth cannot be empty.";
                        }
                        else if (!DateTime.TryParse(DateOfBirth, out _)) {
                            result = "Invalid date format.";
                        }
                        break;
                }
                return result;
            }
        }

    }
}
