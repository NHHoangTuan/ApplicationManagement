using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.DTO
{
    public class BillDTO : INotifyPropertyChanged, ICloneable
    {
        public int MaHoaDon { get; set; }
        public string MaThue { get; set; }
        public int MaPhieu { get; set; }
        public int SoTien { get; set; }
        public int DaNhan { get; set; }
        public EnterpriseDTO? Enterprise { get; set; }
        public string? BillPath { get; set; }


        public BillDTO() { 
        
            MaHoaDon = -1;
            MaThue = "";
            MaPhieu = -1;
            SoTien = -1;
            DaNhan = -1;
            Enterprise = null;
            BillPath = null;
            
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}   
