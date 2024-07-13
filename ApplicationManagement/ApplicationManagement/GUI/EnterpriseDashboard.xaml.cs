using ApplicationManagement.BUS;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicationManagement.GUI
{
    /// <summary>
    /// Interaction logic for EnterpriseDashboard.xaml
    /// </summary>
    public partial class EnterpriseDashboard : Page
    {

        EnterpriseDTO currentEnterprise;
        EnterpriseBUS enterpriseBUS;

        public EnterpriseDashboard()
        {
            InitializeComponent();
            currentEnterprise = new EnterpriseDTO();
            enterpriseBUS = new EnterpriseBUS();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            currentEnterprise = enterpriseBUS.getEnterpriseByTaxID(Login.CurrentAccountID);

            this.DataContext = currentEnterprise;
        }
    }
}
