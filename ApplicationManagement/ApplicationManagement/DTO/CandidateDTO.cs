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

        // IDataErrorInfo 
        public string Error => null;

        public string this[string columnName] {
            get {
                string result = null;
                switch (columnName) {
                    case nameof(CandidateName):
                        if (string.IsNullOrWhiteSpace(CandidateName)) {
                            result = "Tên không được trống!";
                        }
                        break;
                    case nameof(CCCD):
                        if (string.IsNullOrWhiteSpace(CCCD)) {
                            result = "Số CCCD không được trống!";
                        }
                        break;
                    case nameof(Gender):
                        if (string.IsNullOrWhiteSpace(Gender)) {
                            result = "Phải chọn giới tính!";
                        }
                        break;
                    case nameof(PhoneNumber):
                        if (string.IsNullOrWhiteSpace(PhoneNumber)) {
                            result = "Số điện thoại không được trống!";
                        }
                        else if (!System.Text.RegularExpressions.Regex.IsMatch(PhoneNumber, @"^\d{10}$")) {
                            result = "Số điện thoại phải dài chính xác 10 số!";
                        }
                        break;
                    case nameof(DateOfBirth):
                        if (string.IsNullOrWhiteSpace(DateOfBirth)) {
                            result = "Ngày sinh không được trống!";
                        }
                        else if (!DateTime.TryParse(DateOfBirth, out _)) {
                            result = "Định dạng ngày sinh không hợp lệ!";
                        }
                        break;
                }
                return result;
            }
        }

    }
}
