using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.DTO
{
    public class RecruitmentDTO : INotifyPropertyChanged, ICloneable
    {

        public string Vacancies { get; set; }
        public int RecruitNumber { get; set; }
        public int RecruitPeriod { get; set; }
        public string Require { get; set; }
        public DateTime RecruitTime { get; set; }
        public string Logo { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public EnterpriseDTO Enterprise { get; set; }
        public string Background { get; set; }
        public string RecruitForm {  get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }

    }
}
