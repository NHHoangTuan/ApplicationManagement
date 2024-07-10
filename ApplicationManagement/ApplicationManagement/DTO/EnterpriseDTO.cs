using System;
using System.ComponentModel;

namespace ApplicationManagement.DTO {
    public class EnterpriseDTO : INotifyPropertyChanged, ICloneable {

        public string EnterpriseName { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Background { get; set; }
        public string Address { get; set; }
        public string TaxID { get; set; }
        public string Leader { get; set; }
        public string Email { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone() {
            return MemberwiseClone();
        }

        public string Error => null;

        public string this[string columnName] {
            get {
                string result = null;
                switch (columnName) {
                    case nameof(EnterpriseName):
                        if (string.IsNullOrWhiteSpace(EnterpriseName)) {
                            result = "Tên không được trống!";
                        }
                        break;
                    case nameof(Description):
                        if (string.IsNullOrWhiteSpace(Description)) {
                            result = "Mô tả không được trống!";
                        }
                        break;
                    case nameof(Logo):
                        if (string.IsNullOrWhiteSpace(Logo)) {
                            result = "Logo không được trống!";
                        }
                        break;
                    case nameof(Background):
                        if (string.IsNullOrWhiteSpace(Background)) {
                            result = "Nền không được trống!";
                        }
                        break;
                    case nameof(Address):
                        if (string.IsNullOrWhiteSpace(Address)) {
                            result = "Địa chỉ không được trống!";
                        }
                        break;
                    case nameof(TaxID):
                        if (string.IsNullOrWhiteSpace(TaxID)) {
                            result = "Mã số thuế không được trống!";
                        }
                        break;
                    case nameof(Leader):
                        if (string.IsNullOrWhiteSpace(Leader))
                        {
                            result = "Người đại diện không được trống!";
                        }
                        break;
                    case nameof(Email):
                        if (string.IsNullOrWhiteSpace(TaxID))
                        {
                            result = "Email không được trống!";
                        }
                        break;
                }
                return result;
            }
        }

    }
}
