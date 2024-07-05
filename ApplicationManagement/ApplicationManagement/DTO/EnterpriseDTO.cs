using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.DTO
{
    public class EnterpriseDTO : INotifyPropertyChanged, ICloneable
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Background { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
