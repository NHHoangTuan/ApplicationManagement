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

    }
}
