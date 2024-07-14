using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.DTO
{
    public class ApplicationDTO : INotifyPropertyChanged, ICloneable
    {


        public int FormID { get; set; }
        public CandidateDTO Candidate { get; set; }
        public string? Note { get; set; }
        public string Validity { get; set; }
        public string Position { get; set; }
        public EnterpriseDTO Enterprise { get; set; }
        public string? CVPath { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }

    }
}
