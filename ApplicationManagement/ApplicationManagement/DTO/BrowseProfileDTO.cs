using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.DTO
{
    public class BrowseProfileDTO : INotifyPropertyChanged, ICloneable
    {


        public int maPheDuyet { get; set; }
        public int maPhieuUT { get; set; }
        public string maThue {  get; set; }
        public int trangthai { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
