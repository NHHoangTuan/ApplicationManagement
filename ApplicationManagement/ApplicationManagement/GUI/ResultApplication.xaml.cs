using ApplicationManagement.BUS;
using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ResultApplication.xaml
    /// </summary>
    public partial class ResultApplication : Page
    {

        BindingList<ApplicationDTO>? originalList = null; // Store the original list
        BindingList<ApplicationDTO>? listShow = null;
        ApplicationBUS _applicationBUS;

        public ResultApplication()
        {
            InitializeComponent();
            _applicationBUS = new ApplicationBUS();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            originalList = _applicationBUS.getAllResultForCandidate(Login.CurrentAccountID);
            if (originalList != null)
            {
                listShow = new BindingList<ApplicationDTO>(originalList.ToList());
            }

            if (listShow != null)
                resultListView.ItemsSource = listShow;

            if (listShow == null || listShow.Count == 0)
            {
                MessageText.Text = "Opps! Có vẻ bạn cần thêm thời gian, hãy cố đợi nhé";
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
