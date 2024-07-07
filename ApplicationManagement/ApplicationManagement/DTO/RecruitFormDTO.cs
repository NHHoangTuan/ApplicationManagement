using System;
using System.ComponentModel;

namespace ApplicationManagement.DTO
{
    public class RecruitFormDTO : INotifyPropertyChanged, ICloneable
    {

        public string TaxID { get; set; }
        public string Vacancies { get; set; }
        public string Amount { get; set; }
        public int Time { get; set; }
        public string Description { get; set; }
        public DateTime ExactlyDate { get; set; }
        public string Form { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case nameof(TaxID):
                        if (string.IsNullOrWhiteSpace(TaxID))
                        {
                            result = "Mã thuế không được trống!";
                        }
                        break;
                    case nameof(Vacancies):
                        if (string.IsNullOrWhiteSpace(Vacancies))
                        {
                            result = "Vị trí tuyển dụng không được trống!";
                        }
                        break;
                    case nameof(Amount):
                        if (string.IsNullOrWhiteSpace(Amount))
                        {
                            result = "Số lượng tuyển dụng không được trống!";
                        }
                        break;
                    case nameof(Time):
                        if (Time <= 0)
                        {
                            result = "Thời gian đăng tuyển không hợp lệ!";
                        }
                        break;
                    case nameof(Description):
                        if (string.IsNullOrWhiteSpace(Description))
                        {
                            result = "Thông tin yêu cầu không được trống!";
                        }
                        break;
                    case nameof(Form):
                        if (string.IsNullOrWhiteSpace(Form))
                        {
                            result = "Hình thức đăng tuyển không được trống!";
                        }
                        break;
                    case nameof(ExactlyDate):
                        if (ExactlyDate == DateTime.MinValue)
                        {
                            result = "Thời gian chính xác đăng tuyển không được trống!";
                        }
                        break;
                }
                return result;
            }
        }
    }
}
