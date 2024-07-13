using System;
using System.ComponentModel;

namespace ApplicationManagement.DTO {
    public class EnterpriseDTO : INotifyPropertyChanged, ICloneable {

        public string EnterpriseName { get; set; }
        public string LogoPath { get; set; }
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
                    
                    case nameof(LogoPath):
                        if (string.IsNullOrWhiteSpace(LogoPath)) {
                            result = "Logo không được trống!";
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
