using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ApplicationManagement.GUI
{
    /// <summary>
    /// Interaction logic for EnterpriseDetail.xaml
    /// </summary>
    public partial class EnterpriseDetail : Window
    {
        public EnterpriseDetail(EnterpriseDTO b)
        {
            InitializeComponent();
            this.DataContext = b;
        }



    }



}
